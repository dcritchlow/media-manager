namespace MediaManager.SharedKernel
{
  public interface ILog
  {
    void Fatal(string msg);
    void Error(string msg);
    void Warn(string msg);
    void Info(string msg);
    void Debug(string msg);
    void Trace(string msg);
  }
}