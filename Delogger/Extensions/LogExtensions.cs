using Delogger.Scope.Log;

namespace Delogger
{
	public static class LogExtensions
	{
		public static void LogException(this IDLogger logger, Exception exception)
		{
			logger.Log(exception.ToString(), new[] { "Error" });
		}
	}
}