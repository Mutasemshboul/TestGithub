using learn.core.Data;
using learn.core.Repoisitory;
using learn.core.service;
using learn.infra.Repoisitory;
using System;
using System.Collections.Generic;
using System.Text;

namespace learn.infra.service
{
    public class courserservice : Icourseservice
    {
        private readonly Icourse_apirepoisitory repo;
        public courserservice(Icourse_apirepoisitory repo)
        {
            this.repo = repo;
        }
        public bool deleteCourse(int? id)
        {
            return repo.deleteCourse(id);
        }

        public List<course> GetAllCourse()
        {
            return repo.GetAllCourse();
        }

        public course getbyid(int id)
        {
            return repo.getbyid(id);
        }

        public bool insertcourse(course course)
        {
            return repo.insertcourse(course);
        }

        public bool updateCourse(course course)
        {
            return repo.updateCourse(course);
        }
    }
}
