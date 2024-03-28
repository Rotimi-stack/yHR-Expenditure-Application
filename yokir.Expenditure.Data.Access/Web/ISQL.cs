namespace yHR.DataAccess.Web
{
    public interface ISQL
    {
        IConfiguration Config();
        Task<string> GenerateCode(string NumberType);
        Task<string> GenerateID(string NumberType);
        Task<List<T>> Retrieve<T, U>(string storedProcedure, U parameter);
        Task<List<T>> Retrieve<T, U>(string storedProcedure, U parameter, string connectionString);
        Task<T> RetrieveFirstOrDefaultAsync<T, U>(string storedProcedure, U parameter);
        Task<T> RetrieveFirstOrDefaultAsync<T, U>(string storedProcedure, U parameter, string connectionString);
        Task<bool> Save<T>(string storedProcedue, T parameter);
        Task<bool> Save<T>(string storedProcedue, T parameter, string connectionString);
        Task<List<T>> Search<T>(string sql);
    }
}