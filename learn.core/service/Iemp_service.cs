using learn.core.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace learn.core.service
{
    public interface Iemp_service
    {
        public List<emp_dto> get();
        public List<emp_dto> getfnamedate(emp_Date emp);
        public List<emp_dto> getfnamelnamedate(emp_Date emp);

    }
}
