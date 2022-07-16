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
    public class task_repo : Itask_apirepo
    {
        private readonly IDBContext dbContext;

        public task_repo(IDBContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public bool del(int id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("p_ID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = dbContext.dBConnection.ExecuteAsync("TASK_API_tapi.del", parameter, commandType: CommandType.StoredProcedure);
            if (result == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public List<task_api> getalltask()
        {
            IEnumerable<task_api> result = dbContext.dBConnection.Query<task_api>("TASK_API_tapi.getalltask", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public task_api getbyid(int id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("idoftask", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            //select * from course_api where id=idofcourse;

            IEnumerable<task_api> result = dbContext.dBConnection.Query<task_api>("TASK_API_tapi.getbyid", parameter, commandType: CommandType.StoredProcedure);
            //course_api result1 = dbContext.dbConnection.QueryFirstOrDefault<course_api>("course_package_api.getbyid", parameter, commandType: CommandType.StoredProcedure);
            //return result;
            return result.FirstOrDefault();
        }

        public bool ins(task_api task_Api)
        {
            var parameter = new DynamicParameters();

            parameter.Add("p_TASKNNAME", task_Api.TASKNNAME, dbType: DbType.String, direction: ParameterDirection.Input);




            var result = dbContext.dBConnection.Execute("TASK_API_tapi.ins", parameter, commandType: CommandType.StoredProcedure);



            return true;
        }

        public bool upd(task_api task_Api)
        {
            var parameter = new DynamicParameters();
            parameter.Add("p_ID", task_Api.id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            parameter.Add("p_TASKNNAME", task_Api.TASKNNAME, dbType: DbType.String, direction: ParameterDirection.Input);




            var result = dbContext.dBConnection.ExecuteAsync("TASK_API_tapi.upd", parameter, commandType: CommandType.StoredProcedure);



            return true;
        }
    }
}
