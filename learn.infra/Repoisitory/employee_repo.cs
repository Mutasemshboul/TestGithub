using Dapper;
using learn.core.Data;
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
    public class employee_repo : Iemployee_apirepo
    {
        private readonly IDBContext dbContext;

        public employee_repo(IDBContext dbcontext)
        {
            this.dbContext = dbcontext;
        }

        public List<emp_avg> average()
        {
            IEnumerable<emp_avg> result = dbContext.dBConnection.Query<emp_avg>("employee_package_api.average", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public List<cnt_emp_dept> countempindept()
        {
            IEnumerable<cnt_emp_dept> result = dbContext.dBConnection.Query<cnt_emp_dept>("employee_package_api.countempindept", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public List<cnt_emp__task> countempintask()
        {
            IEnumerable<cnt_emp__task> result = dbContext.dBConnection.Query<cnt_emp__task>("employee_package_api.countempintask", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public List<emp_count> countofem()
        {
            IEnumerable<emp_count> result = dbContext.dBConnection.Query<emp_count>("employee_package_api.countofem", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public List<countemp_dto> countsumavg()
        {
            IEnumerable<countemp_dto> result = dbContext.dBConnection.Query<countemp_dto>("employee_package_api.countsumavg", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public bool deleteemp(int id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("idofemp", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = dbContext.dBConnection.ExecuteAsync("employee_package_api.deleteemp", parameter, commandType: CommandType.StoredProcedure);
            if (result == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public List<emp_all_date> filterdate(employee_date employee_Date)
        {
            var parameter = new DynamicParameters();
            parameter.Add("p_CHECKIN", employee_Date.CHECKIN, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            parameter.Add("p_CHECKOUT", employee_Date.CHECKOUT, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            IEnumerable<emp_all_date> result = dbContext.dBConnection.Query<emp_all_date>("employee_package_api.filterdate", parameter, commandType: System.Data.CommandType.StoredProcedure);

            return result.ToList();
        }

        public List<employee_api> filtername(string F_name)
        {
            var parameter = new DynamicParameters();
            parameter.Add("F_name", F_name, dbType: DbType.String, direction: ParameterDirection.Input);
            //select * from course_api where id=idofcourse;

            IEnumerable<employee_api> result = dbContext.dBConnection.Query<employee_api>("employee_package_api.filtername", parameter, commandType: CommandType.StoredProcedure);
            //course_api result1 = dbContext.dbConnection.QueryFirstOrDefault<course_api>("course_package_api.getbyid", parameter, commandType: CommandType.StoredProcedure);
            //return result;
            return result.ToList();
        }

        public List<employee_api> getallemp()
        {
            IEnumerable<employee_api> result = dbContext.dBConnection.Query<employee_api>("employee_package_api.getallemp", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public List<empdept_dto> getallfullnamesalarydept()
        {
            IEnumerable<empdept_dto> result = dbContext.dBConnection.Query<empdept_dto>("employee_package_api.getallfullnamesalarydept", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public employee_api getbyid(int id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("idofemp", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            //select * from course_api where id=idofcourse;

            IEnumerable<employee_api> result = dbContext.dBConnection.Query<employee_api>("employee_package_api.getbyid", parameter, commandType: CommandType.StoredProcedure);
            //course_api result1 = dbContext.dbConnection.QueryFirstOrDefault<course_api>("course_package_api.getbyid", parameter, commandType: CommandType.StoredProcedure);
            //return result;
            return result.FirstOrDefault();
        }

        public List<employee_api> getendcom()
        {
            IEnumerable<employee_api> result = dbContext.dBConnection.Query<employee_api>("employee_package_api.getendcom", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public List<emptask_dto> getfnamelnametask()
        {
            IEnumerable<emptask_dto> result = dbContext.dBConnection.Query<emptask_dto>("employee_package_api.getfnamelnametask", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public bool insertemp(employee_api Empolyee_Api)
        {
            var parameter = new DynamicParameters();

            parameter.Add("fname", Empolyee_Api.fname, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("lname", Empolyee_Api.lname, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("email", Empolyee_Api.email, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("salary", Empolyee_Api.salary, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            parameter.Add("deptid", Empolyee_Api.deptid, dbType: DbType.Int32, direction: ParameterDirection.Input);




            var result = dbContext.dBConnection.ExecuteAsync("employee_package_api.insertemp", parameter, commandType: CommandType.StoredProcedure);



            return true;
        }

        public List<emp_sum> sumofemp()
        {
            IEnumerable<emp_sum> result = dbContext.dBConnection.Query<emp_sum>("employee_package_api.sumofemp", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public bool updateemp(employee_api Empolyee_Api)
        {
            var parameter = new DynamicParameters();
            parameter.Add("idofemp", Empolyee_Api.id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("fname", Empolyee_Api.fname, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("lname", Empolyee_Api.lname, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("email", Empolyee_Api.email, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("salary", Empolyee_Api.salary, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            parameter.Add("deptid", Empolyee_Api.deptid, dbType: DbType.Int32, direction: ParameterDirection.Input);




            var result = dbContext.dBConnection.ExecuteAsync("employee_package_api.insertemp", parameter, commandType: CommandType.StoredProcedure);



            return true;
        }
    }
}
