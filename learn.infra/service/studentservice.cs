using learn.core.Data;
using learn.core.Repoisitory;
using learn.core.service;
using System;
using System.Collections.Generic;
using System.Text;

namespace learn.infra.service
{
    public class studentservice : Istudentservice
    {
        private readonly IstudentRepo repo;
        public studentservice(IstudentRepo repo)
        {
            this.repo = repo;
        }
        public bool DeleteStudent(int? id)
        {
            return repo.DeleteStudent(id);
        }

        public student_api Getbyid(int? id)
        {
            return repo.Getbyid(id);
        }

        public List<student_api> GetStudents()
        {
            return repo.GetStudents();
        }

        public bool InsertStudent(student_api course)
        {
            return repo.InsertStudent(course);
        }

        public bool UpdateStudent(student_api course)
        {
            return repo.UpdateStudent(course);
        }
        public student_api MarkStudent(string fname)
        {
            return repo.MarkStudent(fname);
        }



        public T AllPro<T>(string value, student_api student )
        {
            return repo.AllPro<T>(value, student); 
        }
    }
}
