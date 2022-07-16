using learn.core.Data;
using learn.core.Repoisitory;
using learn.core.service;
using System;
using System.Collections.Generic;
using System.Text;

namespace learn.infra.service
{
    public class dateservice : Idateservice
    {
        private readonly Idate_apirepo dateRepo;
        public dateservice(Idate_apirepo dateRepo)
        {
            this.dateRepo = dateRepo;
        }
        public bool del(int id)
        {
            return dateRepo.del(id);
        }

        public List<date_api> getalldate()
        {
            return dateRepo.getalldate();
        }

        public date_api getbyid(int id)
        {
            return dateRepo.getbyid(id);
        }

        public bool ins(date_api date_Api)
        {
            return dateRepo.ins(date_Api);    
        }

        public bool upd(date_api date_Api)
        {
            return dateRepo.upd(date_Api);  
        }
    }
}
