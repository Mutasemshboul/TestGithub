using learn.core.Data;
using learn.core.Repoisitory;
using learn.core.service;
using System;
using System.Collections.Generic;
using System.Text;

namespace learn.infra.service
{
    public class enrollmaenttaskservice : Ienrollmenttask_service
    {
        private readonly Ienrollmenttask_apirepo enrolltaskRepo;
        public enrollmaenttaskservice(Ienrollmenttask_apirepo enrolltaskRepo)
        {
            this.enrolltaskRepo = enrolltaskRepo;
        }
        public bool del(int id)
        {
            return enrolltaskRepo.del(id);
        }

        public List<enrollmenttask> getallEnrolltask()
        {
            return enrolltaskRepo.getalltask();
        }

        public enrollmenttask getbyid(int id)
        {
            return enrolltaskRepo.getbyid(id);
        }

        public bool ins(enrollmenttask enrollmenttask_Api)
        {
            return enrolltaskRepo.ins(enrollmenttask_Api);
        }

        public bool upd(enrollmenttask enrollmenttask_Api)
        {
            return enrolltaskRepo.upd(enrollmenttask_Api);  
        }
    }
}
