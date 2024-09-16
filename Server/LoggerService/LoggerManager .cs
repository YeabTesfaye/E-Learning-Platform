using Contracts;
using Serilog;

namespace LoggerService;

public class LoggerManager : ILoggerManager
{
    public LoggerManager()
    {
        Log.Logger = new LoggerConfiguration()
        .WriteTo.Console()
        .WriteTo.File("logs/log.txt", rollingInterval: RollingInterval.Day)
        .CreateLogger();

    }
    public void LogDebug(string message)
    {
        Log.Debug(message);
    }

    public void LogError(string message)
    {
        Log.Error(message);
    }

    public void LogInfo(string message)
    {
        Log.Information(message);
    }

    public void LogWarn(string message)
    {
        Log.Warning(message);
    }
}