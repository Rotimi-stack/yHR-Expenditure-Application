using System;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using yHR.DataAccess.Desktop;

namespace yHR.MiddleTier.BusinessManagement
{
    public class BaseMgt
    {
        public readonly IConfiguration _config;
        public readonly ISQL _db;

        public BaseMgt(ISQL db)
        {
            _db = db;
            _config = _db.Config();
        }

    }
}
