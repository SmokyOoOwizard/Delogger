using Delogger.Scope.Log;
using Delogger.Scope.Perf;

namespace Delogger.Scope
{
	public interface IDScope : IDisposable
	{
		IDLogger CreateLogger();
		IDLogger CreateLogger(LoggerCreateOptions options);

		IDPerfMonitor CreatePerfMonitor();
		IDPerfMonitor CreatePerfMonitor(PerfMonitorCreateOptions options);
	}
}