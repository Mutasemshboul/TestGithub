using learn.core.Data;
using learn.core.Repoisitory;
using learn.core.service;
using System;
using System.Collections.Generic;
using System.Text;

namespace learn.infra.service
{
    public class courseApiservice : Icourse_api_service
    {
        private readonly Icourse_api_reposisitory repo;
        public courseApiservice(Icourse_api_reposisitory repo)
        {
            this.repo = repo;
        }

        public bool CreateCourse(course_api course)
        {
            return repo.CreateCourse(course);
        }

        public bool DeleteCourse(int? id)
        {
            return repo.DeleteCourse(id);
        }

        public List<course_api> GetCourses()
        {
            return repo.GetCourses();
        }

        public bool UpdateCourse(course_api course)
        {
            return repo.UpdateCourse(course);
        }


        public course_api Getbyid(int? id)
        {
            return repo.Getbyid(id);
        }
    }
}
