﻿namespace ServiceCourse.Domain.Models
{
    public class CourseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }
        public float Price { get; set; }
        public EnrollmentStatus Status { get; set; }


        public enum EnrollmentStatus
        {
            Abertas = 1,
            Fechadas = 2
        }
    }
}
