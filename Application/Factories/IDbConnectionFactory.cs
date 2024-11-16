using System.Data;

namespace Application.Factories;

public interface IDbConnectionFactory
{
    IDbConnection Connect();
}