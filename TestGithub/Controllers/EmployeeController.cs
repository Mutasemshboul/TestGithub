using learn.core.Data;
using learn.core.DTO;
using learn.core.service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace TestGithub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly Iempolyee_sevice Empservice;
        public EmployeeController(Iempolyee_sevice Empservice)
        {
            this.Empservice = Empservice;

        }
        [HttpDelete("delete/{id}")]
        public bool DeleteDemp(int id)
        {
            return Empservice.deleteemp(id);
        }

        [HttpGet]
        public List<employee_api> Getallemp()
        {
            return Empservice.getallemp();
        }


        [HttpGet("endcom")]
        public List<employee_api> Getallempcom()
        {
            return Empservice.getendcom();
        }
        [HttpGet("count")]
        public int count()
        {
            return Empservice.getallemp().Count();
        }
        [HttpGet("count2")]
        public List<emp_count> count2()
        {
            return Empservice.countofem() ;
        }
        [HttpGet("countsumavg")]
        public List<countemp_dto> countsumavg()
        {
            return Empservice.countsumavg();
        }
        [HttpGet("avg2")]
        public List<emp_avg> avg2()
        {
            return Empservice.average();
        }
        [HttpGet("sum2")]
        public List<emp_sum> sum2()
        {
            return Empservice.sumofemp();
        }

        [HttpGet("sum")]
        public float sum()
        {
            return Empservice.getallemp().Sum(x=>x.salary);
        }

        [HttpGet("avg")]
        public float avg()
        {
            return Empservice.getallemp().Average(x => x.salary);
        }

        [HttpGet("getfull")]
        public List<empdept_dto> getfull()
        {
            return Empservice.getallfullnamesalarydept();
        }
        [HttpPost("filter")]
        public List<emp_all_date> getfulls([FromBody]employee_date emp_date)
        {
            return Empservice.filterdate(emp_date);
        }

        [HttpPost]//insert new record in database
        public bool createcEmp([FromBody] employee_api cc)
        {

            return Empservice.insertemp(cc);
        }

        [HttpPut] //update
        public bool updateEmp([FromBody] employee_api cc)
        {

            return Empservice.updateemp(cc);
        }
        [HttpGet("{id}")]
        public employee_api DeptByid(int id)
        {
            return Empservice.getbyid(id);
        }

        [HttpGet("filter/{F_name}")]
        public List<employee_api> DeptBynname(string F_name)
        {
            return Empservice.filtername(F_name);
        }

        [HttpGet("{id}")]
        public employee_api DeptBydid(int id)
        {
            return Empservice.getbyid(id);
        }
        [HttpGet("emptask")]

        public List<emptask_dto> GetempnameandTask()
        {
            return Empservice.getfnamelnametask();
        }
        [HttpGet("cntempdept")]
        public List<cnt_emp_dept> Getcntempdept()
        {
            return Empservice.countempindept();
        }

        [HttpGet("cntemptask")]
        public List<cnt_emp__task> Getcntemptask()
        {
            return Empservice.countempintask();
        }



    }
}
