using learn.core.Data;
using learn.core.service;
using learn.infra.service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace TestGithub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly Icourseservice coursesrevices;
        public CourseController(Icourseservice coursesrevices)
        {
            this.coursesrevices = coursesrevices;   

        }
        [HttpDelete("delete/{id}")]
        public bool deletecourse(int id)
        {
            return coursesrevices.deleteCourse(id);
        }
        [HttpGet]
        public List<course> course()
        {
            return coursesrevices.GetAllCourse();
        }

        [HttpGet("{id}")]
        public course course( int id)
        {
            return coursesrevices.getbyid(id);
        }
        [HttpPost]//insert new record in database
        public bool createcourse([FromBody] course cc)
        {

            return coursesrevices.insertcourse(cc);
        }
        [HttpPut] //update
        public bool updatecourse([FromBody] course cc)
        {

            return coursesrevices.updateCourse(cc);
        }
        [HttpGet("count")]
        public int countcourse()
        {
            return coursesrevices.GetAllCourse().Count();
        }
        [HttpGet("sum")]
        public int sumcourse()
        {
            int sum = 0;
            foreach(var item in coursesrevices.GetAllCourse())
            {
                sum += (int)item.price;
            }
            return sum;
        }
        [HttpGet("last3rec")]
        public List<course> last3rec()
        {
            List<course> l = new List<course>();
            int j = coursesrevices.GetAllCourse().Count() - 1;
            for (int i = j; i > j-3; i--)
            {
                l.Add(coursesrevices.GetAllCourse()[i]);
            }
            return l;
        }
        [HttpGet("ordererd")]
        public List<course> coursedes()
        {
            List<course> l = new List<course>();
            int j = coursesrevices.GetAllCourse().Count() - 1;
            for (int i = j; i > 0 ; i--)
            {
                l.Add(coursesrevices.GetAllCourse()[i]);
            }
            return l;
        }


    }
}
