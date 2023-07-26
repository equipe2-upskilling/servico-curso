namespace ServiceCourse.Data.Entities
{
    public class Course
    {
        public int CourseId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }
        public double Price { get; set; }
        public int EnrollmentStatusId { get; set; }

        public EnrollmentStatus EnrollmentStatusEnum
        {
            get { return (EnrollmentStatus)EnrollmentStatusId; }
        }
        public enum EnrollmentStatus
        {
            Abertas = 1,
            Fechadas = 2
        }
    }
}
