using BL;
using Microsoft.AspNetCore.Identity;
using System.IO;
using System.Threading.Tasks;
using System;
using Microsoft.AspNetCore.Mvc;
using TawredatProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using TawredatProject.Dtos;
using TawredatProject.Services;
using System.Linq;

namespace TawredatProject.Controllers
{
    public class AccountRepository : IAccountRepository
    {
        SignInManager<ApplicationUser> SignInManager;
        UserManager<ApplicationUser> Usermanager;
        TawredatDbContext Ctx;
        private readonly ISMSService _smsService;
        public AccountRepository(ISMSService smsService, SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> usermanager, TawredatDbContext ctx)
        {
           
            Usermanager = usermanager;
            Ctx = ctx;
            SignInManager = signInManager;
            _smsService = smsService;

        }

      



       



        public async Task<string> SignUpAsync(SignUpModel signUpModel)
        {

            if (signUpModel.PersonalImage != null)
            {
                string ImageName = Guid.NewGuid().ToString() + ".jpg";
                var filePaths = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\Uploads", ImageName);
                using (var stream = System.IO.File.Create(filePaths))
                {
                    await signUpModel.PersonalImage.CopyToAsync(stream);
                }
                signUpModel.ImageProfile = ImageName;
            }
            else
            {
                signUpModel.ImageProfile = "6bfaa416-900f-478b-a44d-984e099bd723.jpg";

            }

            var user = new ApplicationUser()
            {
               
                UserName = signUpModel.UserName,
                FirstName = signUpModel.FirstName,
                FamilyName = signUpModel.FamilyName,
                Email = signUpModel.Email,
                Image = signUpModel.ImageProfile,
                PhoneNumber = signUpModel.PhoneNumber,
                //UserType = signUpModel.UserType
                



            };




            var r = await Usermanager.CreateAsync(user, signUpModel.Password);
            if(r!=null) 
            {
                SendSMSDto dto = new SendSMSDto();
                dto.MobileNumber = user.PhoneNumber;

                var code = await Usermanager.GenerateTwoFactorTokenAsync(user, "Phone");

                user.OTP = code;



                var message = "Your security code is: " + code;
                dto.Body = message;


                var resultt = _smsService.Send(dto.MobileNumber, dto.Body);
                await Usermanager.UpdateAsync(user);

            }

            return r.ToString();
        }



        public async Task<string> LoginAsync(SignInModel signInModel)
        {
            var result = await SignInManager.PasswordSignInAsync(signInModel.UserName, signInModel.Password, true, true);


            return result.ToString();






        }


        [AllowAnonymous, HttpPost("forgot-password")]
        public async Task<string> ForgotPassword(ForgotPasswordViewModel model )
        {

            //if (user != null && await Usermanager.IsEmailConfirmedAsync(user))
            //{
            //    var token = await Usermanager.GeneratePasswordResetTokenAsync(user);
            //    var passwordResetLink = Url.Action("ResetPassword", "Account", new { email = model.Email, token = token }, Request.Scheme);
            //    logger.Log(LogLevel.Warning, passwordResetLink);
            //    return View("ForgotPasswordConfirmation");

            //}

            var user =  Usermanager.Users.Where(a => a.PhoneNumber == model.PhoneNumber).FirstOrDefault();

           
            if (user != null)
            {
                SendSMSDto dto = new SendSMSDto();
                dto.MobileNumber = model.PhoneNumber;

                var code = await Usermanager.GenerateTwoFactorTokenAsync(user, "Phone");

                user.OTP = code;

               

                var message = "Your security code is: " + code;
                dto.Body = message;


                var resultt = _smsService.Send(dto.MobileNumber, dto.Body);
                await Usermanager.UpdateAsync(user);
                //await GenerateForgotPasswordTokenAsync(user);
                var codeToken = await Usermanager.GeneratePasswordResetTokenAsync(user);
                return codeToken;
            }
            else 
            {
                return null;
            }





            


        }



        public async Task<string> ResetPassword(string UserId, string codeToken ,  string Password)
        {
            ResetPasswordViewModel resetPasswordModel = new ResetPasswordViewModel
            {
                Code = codeToken,
                UserId = UserId
            };
            resetPasswordModel.Code = resetPasswordModel.Code.Replace(' ', '+');
            var user = await Usermanager.FindByIdAsync(resetPasswordModel.UserId);
            var result = await Usermanager.ResetPasswordAsync(user, resetPasswordModel.Code, Password);
            if (result.Succeeded)
            {
                return "Succeded";
            }
            else 
            {
                return "failed";
            }
        }

        public async Task<string> pHONEcON(SignUpModel signUpModel)
        {
            var res2 = Usermanager.Users.Where(a => a.Id == signUpModel.Id).FirstOrDefault();
          
            if (res2.OTP == signUpModel.OTP)
            {
                res2.OTP = "";
                await Usermanager.UpdateAsync(res2);
                return "Success";
               

               
            }
            else
            {
                return "wrong code";
            }


        }


        public async Task GenerateForgotPasswordTokenAsync(ApplicationUser user)
        {
            var token = await Usermanager.GeneratePasswordResetTokenAsync(user);
            if (!string.IsNullOrEmpty(token))
            {
                //await SendForgotPasswordEmail(user, token);
            }



        }




    }
}
