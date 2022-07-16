using learn.core.Data;
using learn.core.service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace TestGithub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnrolltaskController : ControllerBase
    {
        private readonly Ienrollmenttask_service EEnrolltaskservice;
        public EnrolltaskController(Ienrollmenttask_service EEnrolltaskservice)
        {
            this.EEnrolltaskservice = EEnrolltaskservice;

        }
        [HttpDelete("delete/{id}")]
        public bool DeleteDept(int id)
        {
            return EEnrolltaskservice.del(id);
        }

        [HttpGet]
        public List<enrollmenttask> Department()
        {
            return EEnrolltaskservice.getallEnrolltask();
        }

        [HttpPost]//insert new record in database
        public bool createcDept([FromBody] enrollmenttask cc)
        {

            return EEnrolltaskservice.ins(cc);
        }

        [HttpPut] //update
        public bool updateDept([FromBody] enrollmenttask cc)
        {

            return EEnrolltaskservice.upd(cc);
        }
        [HttpGet("{id}")]
        public enrollmenttask DeptByid(int id)
        {
            return EEnrolltaskservice.getbyid(id);
        }
    }
}
