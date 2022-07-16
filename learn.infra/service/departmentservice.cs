using learn.core.Data;
using learn.core.Repoisitory;
using learn.core.service;
using System;
using System.Collections.Generic;
using System.Text;

namespace learn.infra.service
{
    public class departmentservice : Idepartment_service
    {
        private readonly Idepartment_apirepo deptRepo;
        public departmentservice(Idepartment_apirepo deptRepo)
        {
            this.deptRepo = deptRepo;
        }
        public bool deleteDept(int id)
        {
            return deptRepo.deleteDept(id);
        }

        public List<Department_api> getallDept()
        {
            return deptRepo.getallDept();
        }

        public Department_api getbyid(int id)
        {
            return deptRepo.getbyid(id);
        }

        public bool insertDept(Department_api Department_Api)
        {
            return deptRepo.insertDept(Department_Api);
        }

        public bool updateDept(Department_api Department_Api)
        {
           return deptRepo.updateDept(Department_Api);
        }
    }
}
