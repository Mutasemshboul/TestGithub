using Dapper;
using learn.core.Data;
using learn.core.domain;
using learn.core.Repoisitory;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;

namespace learn.infra.Repoisitory
{
    public class studentrRepo : IstudentRepo
    {
        private readonly IDBContext dbContext;

        public studentrRepo(IDBContext dbContext)
        {
            this.dbContext = dbContext;
        }



        public T AllPro<T>(string value, student_api student)
        {
            if (value=="Insert")
            {
                var parameter = new DynamicParameters();

                parameter.Add("action", value, dbType: DbType.String, direction: ParameterDirection.Input);

                parameter.Add("firstName", student.fname, dbType: DbType.String, direction: ParameterDirection.Input);
                parameter.Add("lastName", student.lname, dbType: DbType.String, direction: ParameterDirection.Input);
                parameter.Add("bod", student.birthdate, dbType: DbType.DateTime, direction: ParameterDirection.Input);
                parameter.Add("mrk", student.mark, dbType: DbType.Int32, direction: ParameterDirection.Input);
                var result = dbContext.dBConnection.ExecuteAsync("StudentPackage.AllPro", parameter, commandType: CommandType.StoredProcedure);

                return (T)Convert.ChangeType(true, typeof(T));

            }
            else if (value=="Update")
            {
                var parameter = new DynamicParameters();

                parameter.Add("action", value, dbType: DbType.String, direction: ParameterDirection.Input);

                parameter.Add("sid", student.studentID, dbType: DbType.Int32, direction: ParameterDirection.Input);

                parameter.Add("firstName", student.fname, dbType: DbType.String, direction: ParameterDirection.Input);
                parameter.Add("lastName", student.lname, dbType: DbType.String, direction: ParameterDirection.Input);
                parameter.Add("bod", student.birthdate, dbType: DbType.DateTime, direction: ParameterDirection.Input);
                parameter.Add("mrk", student.mark, dbType: DbType.Int32, direction: ParameterDirection.Input);
                var result = dbContext.dBConnection.ExecuteAsync("StudentPackage.AllPro", parameter, commandType: CommandType.StoredProcedure);
                return (T)Convert.ChangeType(true, typeof(T));


            }

            else if (value=="GetAll")
            {
                var parameter = new DynamicParameters();

                parameter.Add("action", value, dbType: DbType.String, direction: ParameterDirection.Input);

                IEnumerable<student_api> result = dbContext.dBConnection.Query<student_api>("StudentPackage.AllPro", commandType: CommandType.StoredProcedure);
                return (T)Convert.ChangeType(result.FirstOrDefault(), typeof(T));



            }
            else
            {
                return (T)Convert.ChangeType(false, typeof(T));

            }
            
        }



        public bool DeleteStudent(int? id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("sid", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = dbContext.dBConnection.Execute("StudentPackage.DeleteStudent", parameter, commandType: CommandType.StoredProcedure);
            if (result == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public student_api Getbyid(int? id)
        {
            throw new NotImplementedException();
        }

        public List<student_api> GetStudents()
        {
            IEnumerable<student_api> result = dbContext.dBConnection.Query<student_api>("StudentPackage.GetStudents", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public bool InsertStudent(student_api student)
        {
            var parameter = new DynamicParameters();

            parameter.Add("firstName", student.fname, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("lastName", student.lname, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("bod", student.birthdate, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            parameter.Add("mrk", student.mark, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = dbContext.dBConnection.ExecuteAsync("StudentPackage.InsertStudent", parameter, commandType: CommandType.StoredProcedure);



            return true;
        }

        public student_api MarkStudent(string fname)
        {
            var parameter = new DynamicParameters();
            parameter.Add("firstName", fname, dbType: DbType.String, direction: ParameterDirection.Input);
            //select* from course_api where id = idofcourse;

            IEnumerable<student_api> result = dbContext.dBConnection.Query<student_api>("StudentPackage.MarkStudent", parameter, commandType: CommandType.StoredProcedure);
            //course_api result1 = dbContext.dbConnection.QueryFirstOrDefault<course_api>("course_package_api.getbyid", parameter, commandType: CommandType.StoredProcedure);
            //return result;
            return result.FirstOrDefault();

        }

        public bool UpdateStudent(student_api student)
        {
            var parameter = new DynamicParameters();
            parameter.Add("sid", student.studentID, dbType: DbType.Int32, direction: ParameterDirection.Input);

            parameter.Add("firstName", student.fname, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("lastName", student.lname, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("bod", student.birthdate, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            parameter.Add("mrk", student.mark, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = dbContext.dBConnection.ExecuteAsync("StudentPackage.UpdateStudent", parameter, commandType: CommandType.StoredProcedure);



            return true;
        }
    }
}
