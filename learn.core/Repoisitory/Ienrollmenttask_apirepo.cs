using learn.core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace learn.core.Repoisitory
{
    public interface Ienrollmenttask_apirepo
    {
        public bool ins(enrollmenttask enrollmenttask_Api);
        public bool upd(enrollmenttask enrollmenttask_Api);
        public bool del(int id);
        public List<enrollmenttask> getalltask();
        public enrollmenttask getbyid(int id);
    }
}
