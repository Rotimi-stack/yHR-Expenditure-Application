namespace yHR.DataAccess.Web;

public class BaseSQL : IBaseSQL
{
    public readonly IConfiguration _config;

    public string? connectionString { get; set; } = "DefaultConnection";
    public BaseSQL(IConfiguration config)
    {
        _config = config;
        connectionString = _config.GetConnectionString(connectionString);
    }
}
