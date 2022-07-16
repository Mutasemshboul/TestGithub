using learn.core.Data;
using learn.core.Repoisitory;
using learn.core.service;
using System;
using System.Collections.Generic;
using System.Text;

namespace learn.infra.service
{
    public class taskservice : Itask_service
    {
        private readonly Itask_apirepo taskRepo;
        public taskservice(Itask_apirepo taskRepo)
        {
            this.taskRepo = taskRepo;
        }
        public bool del(int id)
        {
            return taskRepo.del(id);    
        }

        public List<task_api> getalltask()
        {
            return taskRepo.getalltask();
        }

        public task_api getbyid(int id)
        {
            return taskRepo.getbyid(id);    
        }

        public bool ins(task_api task_Api)
        {
            return taskRepo.ins(task_Api);
        }

        public bool upd(task_api task_Api)
        {
            return taskRepo.upd(task_Api);  
        }
    }
}
