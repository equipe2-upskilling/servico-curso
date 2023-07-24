using System.ComponentModel.DataAnnotations;

namespace ServiceCourse.Web.Models
{
    public class CourseViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }
        public float Price { get; set; }
        public EnrollmentStatus Status { get; set; }

        public enum EnrollmentStatus
        {
            [Display(Name = "Abertas")]
            Abertas = 1,

            [Display(Name = "Fechadas")]
            Fechadas = 2
        }
    }
}