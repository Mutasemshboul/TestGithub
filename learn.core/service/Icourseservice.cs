using learn.core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace learn.core.service
{
    public interface Icourseservice
    {
        public List<course> GetAllCourse();
        public bool insertcourse(course course);
        public bool updateCourse(course course);
        public bool deleteCourse(int? id);
        public course getbyid(int id);
    }
}
