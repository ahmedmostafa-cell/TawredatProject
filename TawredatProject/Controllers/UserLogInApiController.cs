
using BL;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TawredatProject.Controllers;
using TawredatProject.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AlMohamyProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserLogInApiController : ControllerBase
    {
        UserManager<ApplicationUser> Usermanager;
        private readonly IAccountRepository _accountRepository;
        public UserLogInApiController(UserManager<ApplicationUser> usermanager, IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
            Usermanager = usermanager;
        }

        [HttpPost("forget")]
        public async Task<IActionResult> forget([FromForm] ForgotPasswordViewModel forgetModel)
        {

            var result = await _accountRepository.ForgotPassword(forgetModel);

            if (result == null)
            {
                return BadRequest("Enter Phone Number Again");

            }
            return Ok(result);

        }
        [HttpPost("reset")]
        public async Task<IActionResult> reset([FromForm] ResetViewPageModel forgetModel)
        {

            var result = await _accountRepository.ResetPassword(forgetModel.UserId , forgetModel.codeToken , forgetModel.Password);

            if (result != "Succeded")
            {
                return BadRequest("Enter Password Again");

            }
            return Ok("you have reset your password");

        }


        [HttpPost("PhoneCon")]
        public async Task<IActionResult> PhoneCon([FromForm] SignUpModel signUpModel)
        {
            var result = await _accountRepository.pHONEcON(signUpModel);

            if (result == "wrong code")
            {
                return Unauthorized();

            }
            return Ok(result);

        }
        [HttpPost("signup")]
        public async Task<IActionResult> SignUp([FromForm] SignUpModel signUpModel)
        {
            var result = await _accountRepository.SignUpAsync(signUpModel);

            if (result != "Succeeded")
            {
                return BadRequest(result);

            }
            else
            {
                ApplicationUser user = await Usermanager.FindByNameAsync(signUpModel.UserName);

                return Ok(user);

            }

        }


        [HttpPost("login")]
        public async Task<IActionResult> login([FromBody] SignInModel signInModel)
        {
            var result = await _accountRepository.LoginAsync(signInModel);

            if (result == "Failed")
            {
                return BadRequest(result);
            }
            else
            {
                ApplicationUser user = await Usermanager.FindByNameAsync(signInModel.UserName);

                return Ok(user);

            }


        }
        // GET: api/<UserLogInApiController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<UserLogInApiController>/5
        [HttpGet("{id}")]
        public ApplicationUser Get(string id)
        {
            return Usermanager.Users.Where(a => a.Id == id).FirstOrDefault();
        }

        // POST api/<UserLogInApiController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<UserLogInApiController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UserLogInApiController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
