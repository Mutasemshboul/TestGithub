using learn.core.Data;
using learn.core.DTO;
using learn.core.service;
using learn.infra.service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TestGithub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class authnticationController : ControllerBase
    {
        private readonly IAuthenticationservice authenticationservice;
        private readonly Iemailservice emailservice;
        public authnticationController(IAuthenticationservice authenticationservice, Iemailservice emailservice)
        {
            this.authenticationservice = authenticationservice;
            this.emailservice = emailservice;
        }

        [HttpPost]
        public IActionResult authen([FromBody] login_api login)
        {
            var RESULT = authenticationservice.Authentication_jwt(login);

            if (RESULT == null)
            {
                return Unauthorized(); //401
            }
            else
            {
                return Ok(RESULT); //200
            }


        }
        //[HttpPost("name")]
        //public IActionResult sendemail([FromBody] sendemail e)
        //{
        //    return Ok(emailservice.Getlemail(e));

        //}
    }
}
