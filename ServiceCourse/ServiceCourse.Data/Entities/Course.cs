namespace ServiceCourse.Data.Entities
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }
        public float Price { get; set; }
        public int EnrollmentStatusId { get; set; }

        public EnrollmentStatus EnrollmentStatusEnum
        {
            get { return (EnrollmentStatus)EnrollmentStatusId; }
        }
        public enum EnrollmentStatus
        {
            Aguardando = 1,
            Ativo = 2,
            Inativo = 3
        }
    }
}
