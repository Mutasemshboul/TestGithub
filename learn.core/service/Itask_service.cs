using learn.core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace learn.core.service
{
    public interface Itask_service
    {
        public bool ins(task_api task_Api);
        public bool upd(task_api task_Api);
        public bool del(int id);
        public List<task_api> getalltask();
        public task_api getbyid(int id);
    }
}
