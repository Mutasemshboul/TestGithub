using learn.core.Data;
using learn.core.DTO;
using learn.core.Repoisitory;
using learn.core.service;
using System;
using System.Collections.Generic;
using System.Text;

namespace learn.infra.service
{
    public class employeeservice : Iempolyee_sevice
    {
        private readonly Iemployee_apirepo EmpRepo;
        public employeeservice(Iemployee_apirepo EmpRepo)
        {
            this.EmpRepo = EmpRepo;
        }

        public List<emp_avg> average()
        {
            return EmpRepo.average();
        }

        public List<cnt_emp_dept> countempindept()
        {
            return EmpRepo.countempindept();
        }

        public List<cnt_emp__task> countempintask()
        {
            return EmpRepo.countempintask();
        }

        public List<emp_count> countofem()
        {
            return EmpRepo.countofem();
        }

        public List<countemp_dto> countsumavg()
        {
            return EmpRepo.countsumavg();
        }

        public bool deleteemp(int id)
        {
           return EmpRepo.deleteemp(id);
        }

        public List<emp_all_date> filterdate(employee_date employee_Date)
        {
            return EmpRepo.filterdate(employee_Date);   
        }

        public List<employee_api> filtername(string F_name)
        {
            return EmpRepo.filtername(F_name);
        }

        public List<employee_api> getallemp()
        {
            return EmpRepo.getallemp();
        }

        public List<empdept_dto> getallfullnamesalarydept()
        {
            return EmpRepo.getallfullnamesalarydept();
        }

        public employee_api getbyid(int id)
        {
            return EmpRepo.getbyid(id);
        }

        public List<employee_api> getendcom()
        {
            return EmpRepo.getendcom();        
        }

        public List<emptask_dto> getfnamelnametask()
        {
            return EmpRepo.getfnamelnametask();
        }

        public bool insertemp(employee_api Empolyee_Api)
        {
            return EmpRepo.insertemp(Empolyee_Api); 
        }

        public List<emp_sum> sumofemp()
        {
            return EmpRepo.sumofemp();
        }

        public bool updateemp(employee_api Empolyee_Api)
        {
            return EmpRepo.updateemp(Empolyee_Api); 
        }
    }
}
