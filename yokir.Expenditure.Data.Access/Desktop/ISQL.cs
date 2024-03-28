
namespace yHR.DataAccess.Desktop
{
    public interface ISQL
    {
        T Count<T>(string sql, string connectionString);
        string GenerateCode(string NumberType, string connectionString);
        string GenerateRef(string NumberType, string connectionString);
        //string GenerateCode(string NumberType, string connectionString);
        List<T> Retrieve<T, U>(string storedProcedure, U parameter, string connectionString);
        List<T> Retrieve<T, U>(string storedProcedure, U parameter);
        DataSet RetrieveDataSet(string storedProcedureOrCommandText, string connectionString);
        T RetrieveFirstOrDefault<T, U>(string storedProcedure, U parameter, string connectionString);
        bool Save(string storedProcedure, DynamicParameters parameters, string connectionString);
        int Save<T>(string storedProcedure, T parameter, string connectionString);
        List<T> Search<T>(string sql, string connectionString);
        int Take(string sql, string connectionString);

        //I added this line to handle query
        List<T> Query<T>(string sql, DynamicParameters parameters, string connectionString);
        IConfiguration? Config();
    }
}