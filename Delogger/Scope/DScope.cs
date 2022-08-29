using Delogger.Scope.Log;
using Delogger.Scope.Perf;

namespace Delogger.Scope
{
	internal class DScope : IDScope
	{
		protected readonly IDScope? parent;
		protected readonly IInformationBufferWriter buffer;

		public DScope(IDScope? parent, IInformationBufferWriter buffer)
		{
			this.parent = parent;
			this.buffer = buffer;
		}


		public IDLogger CreateLogger()
		{
			return new DLogger(this, buffer, LoggerCreateOptions.Default);
		}

		public IDLogger CreateLogger(LoggerCreateOptions options)
		{
			return new DLogger(this, buffer, options);
		}

		public IDPerfMonitor CreatePerfMonitor()
		{
			return new DPerfMonitor(this, buffer, PerfMonitorCreateOptions.Default);
		}

		public IDPerfMonitor CreatePerfMonitor(PerfMonitorCreateOptions options)
		{
			return new DPerfMonitor(this, buffer, options);
		}

		public virtual void Dispose()
		{

		}
	}
}