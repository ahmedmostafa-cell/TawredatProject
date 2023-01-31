using TawredatProject.Models;
using BL;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace TawredatProject.Controllers
{
    public interface IAccountRepository
    {


        Task<string> pHONEcON(SignUpModel signUpModel);

        Task<string> SignUpAsync(SignUpModel signUpModel);

        Task<string> LoginAsync(SignInModel signInModel);

        Task<string> ForgotPassword(ForgotPasswordViewModel model);


        Task<string> ResetPassword(string UserId, string codeToken, string Password);

    }
}
