using System.Configuration;

namespace ServiceCourse.Data.Context
{
    public class AcademicServiceDbContext
    {
        public string ConnectionString()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ServicoAcademico"].ConnectionString;

            return connectionString;
        }
    }
}
