namespace API.Database;

public class DbConnectionProvider : IDbConnectionProvider
{
    public DbConnectionProvider(string filePath)
    {
        FilePath = filePath;
    }
    public string FilePath { get; } 
}