﻿namespace ServiceCourse.Data.Entities
{
    public class Login
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public string Token { get; set; }
    }
}
