using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Dapper;
using learn.core.Data;
using learn.core.Repoisitory;
using learn.infra.domain;

namespace learn.infra.Repoisitory
{
    public class course_apirepoisitory : Icourse_apirepoisitory
    {
        private readonly DbContext dbContext;

        public course_apirepoisitory(DbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public bool deleteCourse(int? id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("CourseId", id, dbType: System.Data.DbType.Int32, direction:ParameterDirection.Input);
            var result = dbContext.dBConnection.ExecuteAsync("Course_Package.deleteCourse", parameter, commandType: CommandType.StoredProcedure);
            if (result == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public List<course> GetAllCourse()
        {
            IEnumerable<course> result = dbContext.dBConnection.Query<course>("Course_Package.GetAllCourse", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public bool insertcourse(course course)
        {
            var parameter = new DynamicParameters();            
            
            parameter.Add("CourseName", course.coursename, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("Price", course.price, dbType: DbType.Int32, direction: ParameterDirection.Input);


            var result = dbContext.dBConnection.ExecuteAsync("Course_Package.insertcourse", parameter, commandType: CommandType.StoredProcedure);



            return true;
        }
    }
}
