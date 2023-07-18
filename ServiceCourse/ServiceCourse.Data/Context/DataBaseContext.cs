using System.Configuration;

namespace ServiceCourse.Data.Context
{
    public class DataBaseContext
    {
        public string ConnectionString()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["GamaApp"].ConnectionString;

            return connectionString;
        }
    }
}
