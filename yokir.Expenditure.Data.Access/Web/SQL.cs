using yHR.DataAccess.Web;

namespace DSS.CIDS.DataAccess.Web;

public class SQL : BaseSQL, ISQL
{
    public SQL(IConfiguration config) : base(config)
    {
        // Config = base._config;
    }

    public IConfiguration Config()
    {
        return base._config;
    }

    public async Task<bool> Save<T>(string storedProcedue, T parameter, string connectionString)
    {
        try
        {
            using IDbConnection connection = new SqlConnection(connectionString);
            await connection.ExecuteAsync(storedProcedue, parameter, commandType: CommandType.StoredProcedure);

            return true;
        }
        catch (Exception ex)
        {
            string error = ex.Message;
        }

        return false;
    }
    public async Task<bool> Save<T>(string storedProcedue, T parameter)
    {
        try
        {
            using IDbConnection connection = new SqlConnection(connectionString);
            await connection.ExecuteAsync(storedProcedue, parameter, commandType: CommandType.StoredProcedure);

            return true;
        }
        catch (Exception ex)
        {
            string error = ex.Message;
        }

        return false;
    }

    public async Task<List<T>> Retrieve<T, U>(string storedProcedure, U parameter, string connectionString)
    {

        try
        {
            using IDbConnection connection = new SqlConnection(connectionString);

            var rows = await connection.QueryAsync<T>(storedProcedure, parameter,
                commandType: CommandType.StoredProcedure);
            return rows.ToList();

        }
        catch (Exception ex)
        {
            string error = ex.ToString();


        }
        return new List<T>();

    }

    public async Task<List<T>> Retrieve<T, U>(string storedProcedure, U parameter)
    {

        try
        {
            using IDbConnection connection = new SqlConnection(connectionString);

            var rows = await connection.QueryAsync<T>(storedProcedure, parameter,
                commandType: CommandType.StoredProcedure);
            return rows.ToList();

        }
        catch (Exception ex)
        {
            string error = ex.ToString();


        }

        return new List<T>();
    }


    public async Task<T> RetrieveFirstOrDefaultAsync<T, U>(string storedProcedure, U parameter)
    {

        try
        {
            using IDbConnection connection = new SqlConnection(connectionString);

            var data = await connection.QueryFirstOrDefaultAsync<T>(storedProcedure, parameter,
                commandType: CommandType.StoredProcedure);
            return data;

        }
        catch (Exception ex)
        {
            string error = ex.ToString();

        }

        return default;
    }

    public async Task<T> RetrieveFirstOrDefaultAsync<T, U>(string storedProcedure, U parameter, string connectionString)
    {

        try
        {
            using IDbConnection connection = new SqlConnection(connectionString);

            var data = await connection.QueryFirstOrDefaultAsync<T>(storedProcedure, parameter,
                commandType: CommandType.StoredProcedure);
            return data;

        }
        catch (Exception ex)
        {
            string error = ex.ToString();

        }

        return default;

    }
    public async Task<List<T>> Search<T>(string sql)
    {

        try
        {
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                var rows = await connection.QueryAsync<T>(sql, commandType: CommandType.Text);
                return rows.ToList();
            }
        }
        catch (Exception ex)
        {
            string error = ex.ToString();

        }

        return default;
    }
    public async Task<string> GenerateCode(string NumberType)
    {

        try
        {
            using IDbConnection connection = new SqlConnection(connectionString);

            var p = new DynamicParameters();
            p.Add("@NumberType", NumberType, DbType.String);

            var row = await connection.QuerySingleAsync<NewNumberGen>("dbo.GenNewNumber", p,
                commandType: CommandType.StoredProcedure);

            string Segment1 = row.Segment1;
            int Segment3 = row.Segment3;

            string number = Segment3.ToString();
            if (number.Length == 1)
                number = "00" + number;
            else if (number.Length == 2)
                number = "0" + number;

            //DateTime dtDate = DateTime.Today;

            var retVal = Segment1 + number;
            //String.Format("{0}{1}{2}", Segment1, dtDate.ToString("yyMM"), Segment3.ToString("00000"));

            return retVal;

        }
        catch (Exception)
        {

        }
        return null;
    }
    public async Task<string> GenerateID(string NumberType)
    {

        try
        {
            using (IDbConnection connection = new SqlConnection(connectionString))
            {


                var p = new DynamicParameters();
                p.Add("@NumberType", NumberType, DbType.String);


                var row = await connection.QuerySingleAsync<NewNumberGen>("dbo.GenNewNumber", p,
                    commandType: CommandType.StoredProcedure);



                string Segment1 = row.Segment1;
                int Segment3 = row.Segment3;




                DateTime dtDate = DateTime.Today;

                var retVal = String.Format("{0}{1}{2}", Segment1, dtDate.ToString("yyMM"), Segment3.ToString("00000"));



                return retVal;
            }
        }
        catch (Exception)
        {

        }
        return null;
    }
}
