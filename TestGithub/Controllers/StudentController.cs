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
    public class StudentController : ControllerBase
    {
        private readonly Istudentservice studentsrevices;
        public StudentController(Istudentservice studentsrevices)
        {
            this.studentsrevices = studentsrevices;

        }

        [HttpDelete("delete/{id}")]
        public bool DeleteCourse(int id)
        {
            return studentsrevices.DeleteStudent(id);
        }

        [HttpGet]
        public List<student_api> course()
        {
            return studentsrevices.GetStudents();
        }

        [HttpPost]//insert new record in database
        public bool createcourse([FromBody] student_api cc)
        {

            return studentsrevices.InsertStudent(cc);
        }

        [HttpPut] //update
        public bool updatecourse([FromBody] student_api cc)
        {

            return studentsrevices.UpdateStudent(cc);
        }
        [HttpGet("{id}")]
        public student_api course(int id)
        {
            return studentsrevices.Getbyid(id);
        }

        [HttpGet("count")]
        public int CountCourse()
        {
            return studentsrevices.GetStudents().Count();
        }

        [HttpGet("mark/{fname}")]
        public float MarkStudent(string fname)
        {
            return studentsrevices.MarkStudent(fname).mark;
        }
        [HttpGet("All/{value}")]
        public T AllPro<T>(string value, [FromBody] student_api student)
        {
           return studentsrevices.AllPro<T>(value, student);
        }


    }
}
