using learn.core.Data;
using learn.core.Repoisitory;
using learn.core.service;
using learn.infra.Repoisitory;
using System;
using System.Collections.Generic;
using System.Text;

namespace learn.infra.service
{
    public class categoryservice : Icategoryservice
    {
        private readonly Icategoryrepoisitorycs categoreyrepoisitory;
        public categoryservice(Icategoryrepoisitorycs categoreyrepoisitory)
        {
            this.categoreyrepoisitory = categoreyrepoisitory;
        }

        public category_api categorey_Api1(int id)
        {
            return categoreyrepoisitory.getbyid(id);
        }

        public string deletecategorey(int id)
        {
            return categoreyrepoisitory.deletecat(id);
        }

        public List<category_api> getallcategorey()
        {
            return categoreyrepoisitory.getallcat();
        }

        public string insertcategorey(category_api categorey_Api)
        {
            return categoreyrepoisitory.insertcat(categorey_Api);
        }

        public string updatecategorey(category_api categorey_Api)
        {
            return categoreyrepoisitory.updatecat(categorey_Api);
        }
    }
}
