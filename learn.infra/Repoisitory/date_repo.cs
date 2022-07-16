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
    public class date_repo : Idate_apirepo
    {
        private readonly IDBContext dbContext;
        public date_repo(IDBContext dbcontext)
        {
            this.dbContext = dbcontext;
        }
        public bool del(int id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("p_ID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = dbContext.dBConnection.ExecuteAsync("DATE_API_tapi.del", parameter, commandType: CommandType.StoredProcedure);
            if (result == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public List<date_api> getalldate()
        {
            IEnumerable<date_api> result = dbContext.dBConnection.Query<date_api>("DATE_API_tapi.getalldate", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public date_api getbyid(int id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("p_ID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            //select * from course_api where id=idofcourse;

            IEnumerable<date_api> result = dbContext.dBConnection.Query<date_api>("DATE_API_tapi.getbyid", parameter, commandType: CommandType.StoredProcedure);
            //course_api result1 = dbContext.dbConnection.QueryFirstOrDefault<course_api>("course_package_api.getbyid", parameter, commandType: CommandType.StoredProcedure);
            //return result;
            return result.FirstOrDefault();
        }

        public bool ins(date_api date_Api)
        {
            var parameter = new DynamicParameters();

            parameter.Add("p_CHECKIN", date_Api.checkin, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            parameter.Add("p_CHECKOUT", date_Api.checkout, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            parameter.Add("p_EMPLOYEEID", date_Api.EMPLOYEEID, dbType: DbType.Int32, direction: ParameterDirection.Input);




            var result = dbContext.dBConnection.Execute("DATE_API_tapi.ins", parameter, commandType: CommandType.StoredProcedure);



            return true;
        }

        public bool upd(date_api date_Api)
        {
            var parameter = new DynamicParameters();

            parameter.Add("p_CHECKIN", date_Api.checkin, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            parameter.Add("p_CHECKOUT", date_Api.checkout, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            parameter.Add("p_EMPLOYEEID", date_Api.EMPLOYEEID, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("p_ID", date_Api.id, dbType: DbType.Int32, direction: ParameterDirection.Input);




            var result = dbContext.dBConnection.Execute("DATE_API_tapi.upd", parameter, commandType: CommandType.StoredProcedure);



            return true;
        }
    }
}
