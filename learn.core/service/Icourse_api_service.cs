using learn.core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace learn.core.service
{
    public interface Icourse_api_service
    {
        public List<course_api> GetCourses();
        public bool CreateCourse(course_api course);
        public bool UpdateCourse(course_api course);
        public bool DeleteCourse(int? id);
        public course_api Getbyid(int? id);

    }
}
