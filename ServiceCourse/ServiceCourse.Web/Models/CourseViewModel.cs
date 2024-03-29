﻿using System.ComponentModel.DataAnnotations;

namespace ServiceCourse.Web.Models
{
    public class CourseViewModel
    {
        public int CourseId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }
        public double Price { get; set; }
        public EnrollmentStatus Status { get; set; }
        public string CoverImg { get; set; }
        public int TeacherId { get; set; }
        public string TeacherName { get; set; }

        public enum EnrollmentStatus
        {
            [Display(Name = "Abertas")]
            Abertas = 1,

            [Display(Name = "Fechadas")]
            Fechadas = 2
        }
    }
}