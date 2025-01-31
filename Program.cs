using NLog;

private static readonly ILogger Logger = LogManager.GetCurrentClassLogger();

// Example usage:
Logger.Info("Application starting");
Logger.Error(ex, "An error occurred");
Logger.Debug("Debug message");
Logger.Warn("Warning message"); 