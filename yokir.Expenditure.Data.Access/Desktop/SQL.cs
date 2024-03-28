namespace yHR.DataAccess.Desktop
{
    public class SQL : BaseSQL, ISQL
    {
        public SQL(IConfiguration config) : base(config)
        {
            // Config = base._config;
        }

        public IConfiguration Config()
        {
            return _config;
        }
        public List<T> Retrieve<T, U>(string storedProcedure, U parameter, string connectionString)
        {

            try
            {
                using (IDbConnection connection = new SqlConnection(connectionString))
                {
                    var rows = connection.Query<T>(storedProcedure, parameter,
                        commandType: CommandType.StoredProcedure);
                    return rows.ToList();
                }
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
                throw;
            }


        }
        public List<T> Retrieve<T, U>(string storedProcedure, U parameter)
        {

            try
            {
                using (IDbConnection connection = new SqlConnection(connectionString))
                {
                    var rows = connection.Query<T>(storedProcedure, parameter,
                        commandType: CommandType.StoredProcedure);
                    return rows.ToList();
                }
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
                throw;
            }


        }
        public List<T> Search<T>(string sql, string connectionString)
        {

            try
            {
                using (IDbConnection connection = new SqlConnection(connectionString))
                {
                    var rows = connection.Query<T>(sql, commandType: CommandType.Text);
                    return rows.ToList();
                }
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
                throw;
            }


        }
        public T RetrieveFirstOrDefault<T, U>(string storedProcedure, U parameter, string connectionString)
        {

            try
            {
                using (IDbConnection connection = new SqlConnection(connectionString))
                {
                    var data = connection.QueryFirstOrDefault<T>(storedProcedure, parameter,
                        commandType: CommandType.StoredProcedure);
                    return data;
                }
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
                throw;
            }


        }

        public int Save<T>(string storedProcedure, T parameter, string connectionString)
        {
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    if (connection.State == ConnectionState.Closed)
                        connection.Open();

                    var retVal = connection.Execute(storedProcedure, parameter,
                        commandType: CommandType.StoredProcedure);

                    return retVal;

                }
                catch (Exception)
                {

                    throw;
                }
                finally
                {
                    if (connection.State == ConnectionState.Open)
                        connection.Close();
                }

            }

        }
        public int Save<T>(string storedProcedure, T parameter)
        {
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    if (connection.State == ConnectionState.Closed)
                        connection.Open();

                    var retVal = connection.Execute(storedProcedure, parameter,
                        commandType: CommandType.StoredProcedure);

                    return retVal;

                }
                catch (Exception)
                {

                    throw;
                }
                finally
                {
                    if (connection.State == ConnectionState.Open)
                        connection.Close();
                }

            }

        }
        public bool Save(string storedProcedure, DynamicParameters parameters, string connectionString)
        {

            using (var conn = new SqlConnection(connectionString))
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                try
                {
                    var retVal = conn.Execute(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    if (conn.State == ConnectionState.Open)
                        conn.Close();
                }

            }
            return true;
        }
        public string GenerateRef(string NumberType, string connectionString)
        {

            try
            {
                using (IDbConnection connection = new SqlConnection(connectionString))
                {


                    var p = new DynamicParameters();
                    p.Add("@NumberType", NumberType, DbType.String);


                    var row = connection.QuerySingle<NewNumberGen>("dbo.GenNewNumber", p,
                        commandType: CommandType.StoredProcedure);

                    string Segment1 = row.Segment1;
                    int Segment3 = row.Segment3;

                    DateTime dtDate = DateTime.Today;

                    var retVal = string.Format("{0}-{1}-{2}", Segment1, dtDate.ToString("yyMM"), Segment3.ToString("00000"));

                    return retVal;
                }
            }
            catch (Exception ex)
            {

            }

            //if we get here, then something went wrong!!!!
            return null;
        }

        public string GenerateCode(string NumberType, string connectionString)
        {

            try
            {
                using IDbConnection connection = new SqlConnection(connectionString);

                var p = new DynamicParameters();
                p.Add("@NumberType", NumberType, DbType.String);

                var row = connection.QuerySingle<NewNumberGen>("dbo.GenNewNumber", p,
                    commandType: CommandType.StoredProcedure);

                string Segment1 = row.Segment1;
                int Segment3 = row.Segment3;

                string number = Segment3.ToString();
                if (number.Length == 1)
                    number = "00" + number;
                else if (number.Length == 2)
                    number = "0" + number;

                var retVal = Segment1 + number;

                return retVal;

            }
            catch (Exception)
            {

            }
            return null;
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

        public T Count<T>(string sql, string connectionString)
        {
            try
            {
                using (IDbConnection connection = new SqlConnection(connectionString))
                {
                    if (connection.State == ConnectionState.Closed)
                        connection.Open();

                    var rows = connection.Query<T>(sql, commandType: CommandType.Text).FirstOrDefault();

                    return rows;

                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public int Take(string sql, string connectionString)
        {
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    if (connection.State == ConnectionState.Closed)
                        connection.Open();

                    var retVal = connection.Execute(sql, commandType: CommandType.Text);

                    return retVal;

                }
                catch (Exception)
                {

                    throw;
                }
                finally
                {
                    if (connection.State == ConnectionState.Open)
                        connection.Close();
                }

            }

        }

        //MSOLEDBSQL // DataSet //DataTable //DataAdapter

        public DataSet RetrieveDataSet(string storedProcedureOrCommandText, string connectionString)
        {
            using (OleDbDataAdapter adapter = new OleDbDataAdapter())
            {

                OleDbConnection connection = new OleDbConnection();
                connection.ConnectionString = connectionString;

                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                command.CommandText = storedProcedureOrCommandText;

                adapter.SelectCommand = command;

                DataSet ds = new DataSet();
                adapter.Fill(ds);
                adapter.Dispose();

                return ds;

            }
        }


        //added this line of code
        public List<T> Query<T>(string sql, DynamicParameters parameters, string connectionString)
        {
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                var rows = connection.Query<T>(sql, parameters, commandType: CommandType.Text);
                return rows.ToList();
            }
        }

    }
}
