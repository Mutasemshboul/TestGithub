using learn.core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace learn.core.Repoisitory
{
    public interface Icategoryrepoisitorycs
    {
        public string insertcat(category_api category_Api);
        public string updatecat(category_api category_Api);
        public string deletecat(int id);
        public List<category_api> getallcat();
        public category_api getbyid(int id);
    }
}
