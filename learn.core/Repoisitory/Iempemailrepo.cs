using learn.core.Data;
using learn.core.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace learn.core.Repoisitory
{
    public interface Iempemailrepo
    {
        public bool ins(emp_email emp_Email);
        public bool upd(emp_email emp_Email);
        public bool del(int id);
        public bool checkemailisexist(empverifiy emp);
        public bool checkverify(empverifiy emp);
        public bool cheack(empverifiy emp);
    }
}
