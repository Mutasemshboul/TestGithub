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
    public class CategoryController : ControllerBase
    {
        private readonly Icategoryservice categorysrevices;
        public CategoryController(Icategoryservice categoryrevices)
        {
            this.categorysrevices = categoryrevices;

        }

        [HttpDelete("delete/{id}")]
        public string deletecategorey(int id)
        {
            return categorysrevices.deletecategorey(id);
        }

        [HttpGet]
        public List<category_api> Category()
        {
            return categorysrevices.getallcategorey();
        }

        [HttpPost]//insert new record in database
        public string createcourse([FromBody] category_api cc)
        {

            return categorysrevices.insertcategorey(cc);
        }

        [HttpPut] //update
        public string updatecategorey([FromBody] category_api cc)
        {

            return categorysrevices.updatecategorey(cc);
        }
        //[HttpGet("{id}")]
        //public category_api course(int id)
        //{
        //    return categorysrevices.ge(id);
        //}

        [HttpGet("count")]
        public int CountCategory()
        {
            return categorysrevices.getallcategorey().Count();
        }
    }
}
