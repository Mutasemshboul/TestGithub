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
    public class department_repo : Idepartment_apirepo
    {
        private readonly IDBContext dbContext;

        public department_repo(IDBContext dbcontext)
        {
            this.dbContext = dbcontext;
        }
        public bool deleteDept(int id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("idofDept", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = dbContext.dBConnection.ExecuteAsync("Department_package_api.deleteDept", parameter, commandType: CommandType.StoredProcedure);
            if (result == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public List<Department_api> getallDept()
        {
            IEnumerable<Department_api> result = dbContext.dBConnection.Query<Department_api>("Department_package_api.getallDept", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public Department_api getbyid(int id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("idofDept", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            //select * from course_api where id=idofcourse;

            IEnumerable<Department_api> result = dbContext.dBConnection.Query<Department_api>("Department_package_api.getbyid", parameter, commandType: CommandType.StoredProcedure);
            //course_api result1 = dbContext.dbConnection.QueryFirstOrDefault<course_api>("course_package_api.getbyid", parameter, commandType: CommandType.StoredProcedure);
            //return result;
            return result.FirstOrDefault();
        }

        public bool insertDept(Department_api Department_Api)
        {
            var parameter = new DynamicParameters();

            parameter.Add("Deptname", Department_Api.DepartmentName, dbType: DbType.String, direction: ParameterDirection.Input);




            var result = dbContext.dBConnection.ExecuteAsync("Department_package_api.insertDept", parameter, commandType: CommandType.StoredProcedure);



            return true;
        }

        public bool updateDept(Department_api Department_Api)
        {
            var parameter = new DynamicParameters();
            parameter.Add("idofDept", Department_Api.id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            parameter.Add("Deptname", Department_Api.DepartmentName, dbType: DbType.String, direction: ParameterDirection.Input);




            var result = dbContext.dBConnection.Execute("Department_package_api.updateDept", parameter, commandType: CommandType.StoredProcedure);



            return true;
        }
    }
}
