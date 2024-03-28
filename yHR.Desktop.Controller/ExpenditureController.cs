using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using yHR.Common.Data;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace yHR.Desktop.Controller
{
    public class ExpenditureController : BaseController, IExpenditureController
    {
        //public bool Save(Expenditures data)
        //{
        //    var p = new DynamicParameters(new
        //    {

        //        Description = data.Description,
        //        Amount = data.Amount,
        //        Month = data.Month,
        //        Year = data.Year,
        //        Day = data.Day,
        //        DateCreated = data.DateCreated,
        //        ExpenditureID = data.ExpenditureID,
        //    });


        //    string storedProcedure = "ExpenditureAdd";
        //    var retVal = _db.Save(storedProcedure, p, _connectionString);
        //    return retVal;
        //}


        public bool Save(Expenditures data)
        {

            DynamicParameters p = new DynamicParameters();

            p.Add("@Description", data.Description, DbType.String);
            p.Add("@Amount", data.Amount, DbType.Decimal);
            p.Add("@ExpType", data.ExpType, DbType.String);
            if (!string.IsNullOrEmpty(data.ExpTypeSub))
            {
                p.Add("@ExpTypeSub", data.ExpTypeSub, DbType.String);
            }
            else
            {
                p.Add("@ExpTypeSub",DBNull.Value, DbType.String);
            }
            p.Add("@Year", data.Year, DbType.Int32);
            p.Add("@Month", data.Month, DbType.String);
            p.Add("@Day", data.Day, DbType.Int32);
            p.Add("@DateCreated", data.DateCreated, DbType.Date);
            p.Add("@ExpenditureID", data.ExpenditureID, DbType.Int32, ParameterDirection.InputOutput);
            string storedProcedure = "ExpenditureAdd";
            var retVal = _db.Save(storedProcedure, p, _connectionString);
            return retVal;
        }

        public bool SaveExpType(CodeExpType data)
        {
            DynamicParameters p = new DynamicParameters();
            p.Add("@Code", data.Code, DbType.String);
            p.Add("@Descrip", data.Descrip, DbType.String);
            p.Add("@DateCreated", data.DateCreated, DbType.Date);

            string storedProcedure = "CodeExpTypeAdd";
            var retVal = _db.Save(storedProcedure, p, _connectionString);
            return retVal;
        }

        public bool SaveExpSubType(CodeExpSubType data)
        {
            DynamicParameters p = new DynamicParameters();
            p.Add("@ExpType", data.ExpType, DbType.String);
            p.Add("@Code", data.Code, DbType.String);
            p.Add("@Descrip", data.Descrip, DbType.String);
            p.Add("@DateCreated", data.DateCreated, DbType.Date);

            string storedProcedure = "CodeExpSubTypeAdd";
            var retVal = _db.Save(storedProcedure, p, _connectionString);
            return retVal;
        }



        public List<Expenditures> Search(string strFilter, string strSort)
        {

            string filter = BuildSelectCommand2(strFilter, strSort);
            string storedProcdeure = "dbo.ExpendituresRetBySearch";
            DynamicParameters p = new DynamicParameters();
            p.Add("@Filter", filter, DbType.String);
            List<Expenditures> retVal = _db.Retrieve<Expenditures, dynamic>(storedProcdeure, p, _connectionString);
            return retVal;

        }


        public bool UpdateExpType(CodeExpType data)
        {
            var p = new DynamicParameters(new
            {

                Code = data.Code,
                Descrip = data.Descrip,

            });
            string storedProcedure = "dbo.ExpTypeUpdate";
            var retVal = _db.Save(storedProcedure, p, _connectionString);
            return retVal;

        }

        public bool UpdateExpSubType(CodeExpSubType data)
        {
            var p = new DynamicParameters(new
            {

                Code = data.Code,
                Descrip = data.Descrip,

            });
            string storedProcedure = "dbo.CodeExpSubTypeUpdate";
            var retVal = _db.Save(storedProcedure, p, _connectionString);
            return retVal;

        }



        private string BuildSelectCommand2(string strFilter, string strSort)
        {
            string strSQL = null;
            try
            {

                StringBuilder sb = new StringBuilder();


                if (strFilter != null && strFilter.Length > 0)
                    sb.Append(" WHERE " + strFilter);

                if (strSort != null && strSort.Length > 0)
                    sb.Append(" ORDER BY " + strSort);

                strSQL = sb.ToString();
                return strSQL;
            }
            catch (Exception e)
            {
                //LogWriter.WriteError(e.Message);
            }
            return strSQL;
        }



    }
}
