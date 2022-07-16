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
    public class enrollmenttask_repo : Ienrollmenttask_apirepo
    {
        private readonly IDBContext dbContext;

        public enrollmenttask_repo(IDBContext dbcontext)
        {
            this.dbContext = dbcontext;
        }
        public bool del(int id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("p_ID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = dbContext.dBConnection.ExecuteAsync("ENROLLMENTTASK_API_tapi.del", parameter, commandType: CommandType.StoredProcedure);
            if (result == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public List<enrollmenttask> getalltask()
        {
            IEnumerable<enrollmenttask> result = dbContext.dBConnection.Query<enrollmenttask>("ENROLLMENTTASK_API_tapi.getallEnrolltask", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public enrollmenttask getbyid(int id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("p_ID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            //select * from course_api where id=idofcourse;

            IEnumerable<enrollmenttask> result = dbContext.dBConnection.Query<enrollmenttask>("ENROLLMENTTASK_API_tapi.getbyid", parameter, commandType: CommandType.StoredProcedure);
            //course_api result1 = dbContext.dbConnection.QueryFirstOrDefault<course_api>("course_package_api.getbyid", parameter, commandType: CommandType.StoredProcedure);
            //return result;
            return result.FirstOrDefault();
        }

        public bool ins(enrollmenttask enrollmenttask_Api)
        {
            var parameter = new DynamicParameters();

            parameter.Add("p_EMPLOYEEID", enrollmenttask_Api.employeeid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("p_TASKID", enrollmenttask_Api.taskid, dbType: DbType.Int32, direction: ParameterDirection.Input);




            var result = dbContext.dBConnection.ExecuteAsync("ENROLLMENTTASK_API_tapi.ins", parameter, commandType: CommandType.StoredProcedure);



            return true;
        }

        public bool upd(enrollmenttask enrollmenttask_Api)
        {
            var parameter = new DynamicParameters();
            parameter.Add("p_ID", enrollmenttask_Api.id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("p_EMPLOYEEID", enrollmenttask_Api.employeeid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("p_TASKID", enrollmenttask_Api.taskid, dbType: DbType.Int32, direction: ParameterDirection.Input);




            var result = dbContext.dBConnection.ExecuteAsync("ENROLLMENTTASK_API_tapi.upd", parameter, commandType: CommandType.StoredProcedure);



            return true;
        }
    }
}
