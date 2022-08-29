using Delogger.Scope.Log;

namespace Delogger.Scope.Perf
{
	public interface IDPerfMonitor : IDLogger, IDisposable
	{
		void AddAttachment(string key, object attachment);
	}
}