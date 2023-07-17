using System.Configuration;

namespace Service.CourseGama.Data.Context
{
    public class DataBaseConfig
    {
        public string ConnectionString()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["GamaApp"].ConnectionString;

            return connectionString;
        }
    }
}
