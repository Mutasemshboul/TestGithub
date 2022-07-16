using learn.core.Data;
using learn.core.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace learn.core.Repoisitory
{
    public interface Iemployee_apirepo
    {
        public bool insertemp(employee_api Empolyee_Api);
        public bool updateemp(employee_api Empolyee_Api);
        public bool deleteemp(int id);
        public List<employee_api> getallemp();
        public employee_api getbyid(int id);
        public List<empdept_dto> getallfullnamesalarydept();
        public List<countemp_dto> countsumavg();
        public List<emp_avg> average();
        public List<emp_sum> sumofemp();
        public List<emp_count> countofem();
        public List<emp_all_date> filterdate(employee_date employee_Date);

        public List<employee_api> getendcom();
        public List<employee_api> filtername(string F_name);
        public List<emptask_dto> getfnamelnametask();

        public List<cnt_emp_dept> countempindept();
        public List<cnt_emp__task> countempintask();






    }
}
