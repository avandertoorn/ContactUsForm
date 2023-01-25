namespace API.Database;

public class DbConnectionProvider : IDbConnectionProvider
{
    public string FilePath { get; } = Path.Combine(Environment.CurrentDirectory, "ContactMessages.json");
}