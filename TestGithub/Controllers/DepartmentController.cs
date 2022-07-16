using learn.core.Data;
using learn.core.service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace TestGithub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly Idepartment_service Deptevices;
        public DepartmentController(Idepartment_service Deptevices)
        {
            this.Deptevices = Deptevices;

        }

        [HttpDelete("delete/{id}")]
        public bool DeleteDept(int id)
        {
            return Deptevices.deleteDept(id);
        }

        [HttpGet]
        public List<Department_api> Department()
        {
            return Deptevices.getallDept();
        }

        [HttpPost]//insert new record in database
        public bool createcDept([FromBody] Department_api cc)
        {

            return Deptevices.insertDept(cc);
        }

        [HttpPut] //update
        public bool updateDept([FromBody] Department_api cc)
        {

            return Deptevices.updateDept(cc);
        }
        [HttpGet("{id}")]
        public Department_api DeptByid(int id)
        {
            return Deptevices.getbyid(id);
        }



    }
}
