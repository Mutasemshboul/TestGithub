using learn.core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace learn.core.service
{
    public interface Ienrollmenttask_service
    {
        public bool ins(enrollmenttask enrollmenttask_Api);
        public bool upd(enrollmenttask enrollmenttask_Api);
        public bool del(int id);
        public List<enrollmenttask> getallEnrolltask();
        public enrollmenttask getbyid(int id);
    }
}
