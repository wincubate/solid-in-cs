namespace Admin.Domain.Logging.Interfaces
{
    public interface ILoggerFactory
    {
        ILogger Create(string name);
    }
}
