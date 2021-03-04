namespace Unite.Data.Services.Configuration.Options
{
    public interface ISqlOptions
    {
        string Host { get; }
        string Database { get; }
        string User { get; }
        string Password { get; }
    }
}
