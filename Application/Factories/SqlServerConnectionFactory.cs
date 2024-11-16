using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Application.Factories;

public class SqlServerConnectionFactory(IConfiguration configuration) : IDbConnectionFactory
{
    public IDbConnection Connect()
    {
        return new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
    }
}