﻿using learn.core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace learn.core.Repoisitory
{
    public interface Icourse_apirepoisitory
    {
        public List<course> GetAllCourse();
        public bool insertcourse(course course);
        public bool deleteCourse(int? id);
    }
}
