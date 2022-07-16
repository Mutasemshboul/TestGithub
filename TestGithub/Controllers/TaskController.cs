using learn.core.Data;
using learn.core.service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace TestGithub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly Itask_service taskService;
        public TaskController(Itask_service taskService)
        {
            this.taskService = taskService;

        }

        [HttpDelete("delete/{id}")]
        public bool DeleteTask(int id)
        {
            return taskService.del(id);
        }

        [HttpGet]
        public List<task_api> Getalltask()
        {
            return taskService.getalltask();
        }

        [HttpPost]//insert new record in database
        public bool createcTask([FromBody] task_api cc)
        {

            return taskService.ins(cc);
        }

        [HttpPut] //update
        public bool updateTask([FromBody] task_api cc)
        {

            return taskService.upd(cc);
        }
        [HttpGet("{id}")]
        public task_api GetByid(int id)
        {
            return taskService.getbyid(id);
        }

    }
}
