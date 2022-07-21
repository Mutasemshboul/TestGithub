using learn.core.Data;
using learn.core.DTO;
using learn.core.service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TestGithub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class verificationController : ControllerBase
    {
        private readonly Iempemailservice iempemailserviec;
        private readonly Iemailservice iemailservice;
        public verificationController(Iempemailservice iempemailserviec, Iemailservice iemailservice)
        {
            this.iempemailserviec = iempemailserviec;   
            this.iemailservice = iemailservice;
        }
        [HttpPost]
        public bool ins(emp_email e)
        {
            return iempemailserviec.ins(e);
        }

        [HttpPost("upd")]
        public bool upd(emp_email e)
        {
            return iempemailserviec.upd(e);
        }
        [HttpPost("iemailservice")]
        public IActionResult sendemail([FromBody] empverifiy e)
        {
            string emailservice1 = iemailservice.GetEmail(e);
            if (emailservice1 == "true")
            {
                return Ok("send");


            }
            else
            {
                return BadRequest("email does not exist");
            }



        }

        [HttpPost("iemail")]
        public bool sende([FromBody] empverifiy e)
        {
            return iempemailserviec.cheack(e);
        }
    }
}
