using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace yHR.DataAccess.Desktop
{
    public class BaseSQL : IBaseSQL
    {
        public readonly IConfiguration _config;

        public string? connectionString { get; set; } = "DefaultConnection";
        public BaseSQL(IConfiguration config)
        {
            _config = config;
            connectionString = _config.GetConnectionString(connectionString); //.ConnectionStrings("DefaultConnection").ConnectionString; //
        }
    }
}
