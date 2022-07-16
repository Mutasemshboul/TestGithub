using learn.core.Data;
using learn.core.service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace TestGithub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseApiController : ControllerBase
    {
        private readonly Icourse_api_service coursesrevices;
        public CourseApiController(Icourse_api_service coursesrevices)
        {
            this.coursesrevices = coursesrevices;

        }

        [HttpDelete("delete/{id}")]
        public bool DeleteCourse(int id)
        {
            return coursesrevices.DeleteCourse(id);
        }

        [HttpGet]
        public List<course_api> course()
        {
            return coursesrevices.GetCourses();
        }

        [HttpPost]//insert new record in database
        public bool createcourse([FromBody] course_api cc)
        {

            return coursesrevices.CreateCourse(cc);
        }

        [HttpPut] //update
        public bool updatecourse([FromBody] course_api cc)
        {

            return coursesrevices.UpdateCourse(cc);
        }
        [HttpGet("{id}")]
        public course_api course(int id)
        {
            return coursesrevices.Getbyid(id);
        }

        [HttpGet("count")]
        public int CountCourse()
        {
            return coursesrevices.GetCourses().Count();
        }






    }
}
