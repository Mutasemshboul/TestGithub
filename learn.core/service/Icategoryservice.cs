using learn.core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace learn.core.service
{
    public interface Icategoryservice
    {
        public string insertcategorey(category_api categorey_Api);
        public string updatecategorey(category_api categorey_Api);
        public string deletecategorey(int id);
        public List<category_api> getallcategorey();

        public category_api categorey_Api1(int id);
    }
}
