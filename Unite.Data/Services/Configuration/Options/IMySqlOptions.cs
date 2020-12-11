namespace Unite.Data.Services.Configuration.Options
{
    public interface IMySqlOptions
    {
        string Host { get; }
        string Database { get; }
        string User { get; }
        string Password { get; }
    }
}
