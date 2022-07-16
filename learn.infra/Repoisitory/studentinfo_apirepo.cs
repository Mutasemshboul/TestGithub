using Dapper;
using learn.core.domain;
using learn.core.DTO;
using learn.core.Repoisitory;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace learn.infra.Repoisitory
{
    public class studentinfo_apirepo : Istudentinfoapirepo
    {
        private readonly IDBContext dbcontext;

        public studentinfo_apirepo(IDBContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }
        public List<studentinfo> Getflmcc()
        {
            IEnumerable<studentinfo> result = dbcontext.dBConnection.Query<studentinfo>("Course_Package.GetAllCourse", commandType: CommandType.StoredProcedure);
            return result.ToList();

        }
    }
}
