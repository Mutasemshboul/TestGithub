using Dapper;
using learn.core.Data;
using learn.core.domain;
using learn.core.Repoisitory;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace learn.infra.Repoisitory
{
    public class categoryrepoisitory : Icategoryrepoisitorycs
    {
        private readonly IDBContext dbcontext;

        public categoryrepoisitory(IDBContext dbcontext)
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
            var parameter = new DynamicParameters();
            parameter.Add("idofcat", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<category_api> result = dbcontext.dBConnection.Query<category_api>("categorey_package_api.getbyid", parameter, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();

        }

        public string insertcat(category_api category_Api)
        {
            var parameter = new DynamicParameters();
            parameter.Add("categoreyname", category_Api.catname, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("dateofcat", category_Api.catdate, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            var result = dbcontext.dBConnection.ExecuteAsync("categorey_package_api.insertcat", parameter, commandType: CommandType.StoredProcedure);
            return "Valid";
        }

        public string updatecat(category_api category_Api)
        {
            var parameter = new DynamicParameters();
            parameter.Add("categoreyname", category_Api.catname, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("dateofcat", category_Api.catdate, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            parameter.Add("idofcat", category_Api.id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = dbcontext.dBConnection.ExecuteAsync("categorey_package_api.updatecat", parameter, commandType: CommandType.StoredProcedure);
            return "Valid";
        }
    }
}
