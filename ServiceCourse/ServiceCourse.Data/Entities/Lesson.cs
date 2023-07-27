namespace ServiceCourse.Data.Entities
{
    public class Lesson
    {
        public int LessonId { get; set; }
        public int CourseId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string LessonUrl { get; set; }
        public string Image { get; set; }
    }
}
