using learn.core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace learn.core.service
{
    public interface Istudentservice
    {
        public List<student_api> GetStudents();
        public bool InsertStudent(student_api course);
        public bool UpdateStudent(student_api course);
        public bool DeleteStudent(int? id);
        public student_api Getbyid(int? id);
        public student_api MarkStudent(string fname);
        public T AllPro<T>(string value, student_api student) ;



    }
}
