using learn.core.Data;
using learn.core.service;
using learn.infra.service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

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
        [HttpDelete]
        public bool deletecourse(int id)
        {
            return coursesrevices.deleteCourse(id);
        }
        [HttpGet]
        public List<course> course()
        {
            return coursesrevices.GetAllCourse();
        }

        [HttpGet("/(id)")]
        public course course([FromBody] int id)
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

    }
}
