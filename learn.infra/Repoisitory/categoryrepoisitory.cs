using Dapper;
using learn.core.Data;
using learn.core.Repoisitory;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace learn.infra.Repoisitory
{
    internal class categoryrepoisitory : Icategoryrepoisitorycs
    {
        private readonly Dbcontext dbcontext;

        public categoryrepoisitory(Dbcontext dbcontext)
        {
            this.dbcontext = dbcontext;
        }

        public string deletecat(int id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("idofcat", id,dbType:DbType.Int32,direction:ParameterDirection.Input);
            var result = dbcontext.dBConnection.ExecuteAsync("categorey_package_api.deletecat", parameter, commandType:CommandType.StoredProcedure );
            return "Valid";
        }

        public List<category_api> getallcat()
        {
            IEnumerable<category_api> result = dbcontext.dBConnection.Query<category_api>("categorey_package_api.getallcat",commandType:CommandType.StoredProcedure);

            return result.ToList();
        }

        public category_api getbyid(int id)
        {
            throw new NotImplementedException();
        }

        public string insertcat(category_api category_Api)
        {
            throw new NotImplementedException();
        }

        public string updatecat(category_api category_Api)
        {
            throw new NotImplementedException();
        }
    }
}
