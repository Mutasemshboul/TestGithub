using learn.core.Data;
using learn.core.service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace TestGithub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DateController : ControllerBase
    {
        private readonly Idateservice dateService;
        public DateController(Idateservice dateService)
        {
            this.dateService = dateService;

        }

        [HttpDelete("delete/{id}")]
        public bool DeleteDept(int id)
        {
            return dateService.del(id);
        }

        [HttpGet]
        public List<date_api> Department()
        {
            return dateService.getalldate();
        }

        [HttpPost]//insert new record in database
        public bool createcDept([FromBody] date_api cc)
        {

            return dateService.ins(cc);
        }

        [HttpPut] //update
        public bool updateDept([FromBody] date_api cc)
        {

            return dateService.upd(cc);
        }
        [HttpGet("{id}")]
        public date_api DeptByid(int id)
        {
            return dateService.getbyid(id);
        }
    }
}
