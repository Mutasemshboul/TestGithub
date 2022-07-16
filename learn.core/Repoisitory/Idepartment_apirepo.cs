using learn.core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace learn.core.Repoisitory
{
    public interface Idepartment_apirepo

    {
        public bool insertDept(Department_api Department_Api);
        public bool updateDept(Department_api Department_Api);
        public bool deleteDept(int id);
        public List<Department_api> getallDept();
        public Department_api getbyid(int id);
    }
}
