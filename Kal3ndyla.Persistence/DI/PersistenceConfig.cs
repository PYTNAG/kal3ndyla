namespace Kal3ndyla.Persistence.DI;

public class PersistenceConfig(string connectionString)
{
    public string ConnectionString { get; } = connectionString;
}