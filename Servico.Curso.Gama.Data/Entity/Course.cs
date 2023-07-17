﻿namespace Service.CourseGama.Data.Entity
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }
        public float Price { get; set; }
        public int EnrollmentStatusId { get; set; }
    }
}
