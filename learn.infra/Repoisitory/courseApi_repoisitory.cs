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
    public class courseApi_repoisitory : Icourse_api_reposisitory
    {
        private readonly IDBContext dbContext;

        public courseApi_repoisitory(IDBContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public bool DeleteCourse(int? id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("cid", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = dbContext.dBConnection.Execute("CoursePackage_api.deleteCourse", parameter, commandType: CommandType.StoredProcedure);
            if (result == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public List<course_api> GetCourses()
        {
            //We Used IEnumerable to return a key and value
            IEnumerable<course_api> result = dbContext.dBConnection.Query<course_api>("CoursePackage_api.GetCourses", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public course_api Getbyid(int? id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("cid", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            //select* from course_api where id = idofcourse;

            IEnumerable<course_api> result = dbContext.dBConnection.Query<course_api>("CoursePackage_api.Getbyid", parameter, commandType: CommandType.StoredProcedure);
            //course_api result1 = dbContext.dbConnection.QueryFirstOrDefault<course_api>("course_package_api.getbyid", parameter, commandType: CommandType.StoredProcedure);
            //return result;
            return result.FirstOrDefault();
        }

        public bool CreateCourse(course_api course)
        {
            var parameter = new DynamicParameters();

            parameter.Add("cName", course.coursename, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("cPrice", course.price, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("cStartdate", course.startdate, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            parameter.Add("cEnddate", course.enddate, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            parameter.Add("cImagename", course.imagename, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("cCategoryid", course.categoryid, dbType: DbType.Int32, direction: ParameterDirection.Input);




            var result = dbContext.dBConnection.ExecuteAsync("CoursePackage_api.CreateCourse", parameter, commandType: CommandType.StoredProcedure);



            return true;
        }

        public bool UpdateCourse(course_api course)
        {
            var parameter = new DynamicParameters();
            parameter.Add("cid", course.courseid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("cName", course.coursename, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("cPrice", course.price, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("cStartdate", course.startdate, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            parameter.Add("cEnddate", course.enddate, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            parameter.Add("cImagename", course.imagename, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("cCategoryid", course.categoryid, dbType: DbType.Int32, direction: ParameterDirection.Input);






            var result = dbContext.dBConnection.Execute("CoursePackage_api.UpdateCourse", parameter, commandType: CommandType.StoredProcedure);



            return true;

        }
    }
}
