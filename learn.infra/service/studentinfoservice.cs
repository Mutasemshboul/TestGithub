using learn.core.DTO;
using learn.core.Repoisitory;
using learn.core.service;
using System;
using System.Collections.Generic;
using System.Text;

namespace learn.infra.service
{
    public class studentinfoservice : Istudentinfo_service
    {
        private readonly Istudentinfoapirepo stdrepo;

        public studentinfoservice(Istudentinfoapirepo stdrepo)
        {
            this.stdrepo = stdrepo;
        }

        public List<studentinfo> get()
        {
            throw new NotImplementedException();
        }
    }
}
