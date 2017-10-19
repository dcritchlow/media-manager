using NLog;

namespace MediaManager.SharedKernel
{
  public class NLog : ILog
  {
    private readonly Logger _logger = LogManager.GetCurrentClassLogger();

    public void Fatal(string msg)
    {
      _logger.Fatal(msg);
    }

    public void Error(string msg)
    {
      _logger.Error(msg);
    }

    public void Warn(string msg)
    {
      _logger.Warn(msg);
    }

    public void Info(string msg)
    {
      _logger.Info(msg);
    }

    public void Debug(string msg)
    {
      _logger.Debug(msg);
    }

    public void Trace(string msg)
    {
      _logger.Trace(msg);
    }
  }
}