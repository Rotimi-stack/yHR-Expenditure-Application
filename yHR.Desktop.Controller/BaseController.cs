using Microsoft.Extensions.Configuration;
using yHR.DataAccess.Desktop;

namespace yHR.Desktop.Controller
{
    public class BaseController
    {
        public readonly ISQL _db;
        public IConfiguration _config;

        public string _connectionString;
        public string _connectionString_oledb;
        public BaseController()
        {
            _db = new SQL(_config);

            _connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString; //_config.GetConnectionString("DefaultConnection").ToString();
            _connectionString_oledb = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultOLEDB"].ConnectionString; //Get and set the connection strings
        }
    }
}
