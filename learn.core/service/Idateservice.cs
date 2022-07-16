using learn.core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace learn.core.service
{
    public interface Idateservice
    {
        public bool ins(date_api enrollmenttask_Api);
        public bool upd(date_api enrollmenttask_Api);
        public bool del(int id);
        public List<date_api> getalldate();
        public date_api getbyid(int id);
    }
}
