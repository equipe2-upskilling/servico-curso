namespace ServiceCourse.Web.Models
{
    public class LoginViewModel
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
    }
}