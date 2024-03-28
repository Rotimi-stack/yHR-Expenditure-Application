using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using yHR.Common.Data;

namespace yHR.Desktop.Controller
{
    public class SetUpController : BaseController, ISetUpController
    {
        public List<CodeTypeData> GetCodeTable(Utility.CodeTable codeTable)
        {
            string storedProcedure = "dbo.CodeTypeRetByTable";
            string ct = codeTable.ToString();
            DynamicParameters p = new DynamicParameters();
            p.Add("TableName", ct, System.Data.DbType.String);
            var data = _db.Retrieve<CodeTypeData, dynamic>(storedProcedure,p,_connectionString);
            return data;
        }
    }
}
