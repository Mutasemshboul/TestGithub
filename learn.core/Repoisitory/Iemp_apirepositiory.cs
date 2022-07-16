using learn.core.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace learn.core.Repoisitory
{
    public interface Iemp_apirepositiory
    {
        public List<emp_dto> getfnamelnamesalary();
        public List<emp_dto> getfnamedate(emp_Date emp);
        public List<emp_dto> getfnamelnamedate(emp_Date emp);
    }
}
