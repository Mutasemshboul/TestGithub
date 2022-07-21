using learn.core.Data;
using learn.core.DTO;
using learn.core.Repoisitory;
using learn.core.service;
using System;
using System.Collections.Generic;
using System.Text;

namespace learn.infra.service
{
    public class empemailservice: Iempemailservice
    {
        private readonly Iempemailrepo iempemailrepo;

        public empemailservice(Iempemailrepo iempemailrepo)
        {
            this.iempemailrepo = iempemailrepo; 
        }
        public  bool ins(emp_email emp_Email)
        {
            return iempemailrepo.ins(emp_Email);
        }

        public bool upd(emp_email emp_Email)
        {
            return iempemailrepo.upd(emp_Email);
        }

        public bool del(int id)
        {
            throw new NotImplementedException();
        }

        public bool cheack(empverifiy emp)
        {
            return iempemailrepo.cheack(emp);
        }
    }
}
