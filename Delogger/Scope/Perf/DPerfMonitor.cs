using Delogger.Scope.Log;
using System.Diagnostics;

namespace Delogger.Scope.Perf
{
	internal class DPerfMonitor : DScope, IDPerfMonitor
	{
		private readonly PerfMonitorCreateOptions options;
		private readonly Stopwatch timer = new();
		private readonly Queue<RecordedLog> logs = new();

		private readonly List<KeyValuePair<string, string>> attachments = new();

		public DPerfMonitor(IDScope parent, IInformationBufferWriter buffer, PerfMonitorCreateOptions options) : base(parent, buffer)
		{
			this.options = options;

			timer.Start();
		}

		public void AddAttachment(string key, object attachment)
		{
			attachments.Add(new KeyValuePair<string, string>(key, attachment?.ToString() ?? "null"));
		}

		public void Log(string message, string[]? tags = null, object[]? args = null, KeyValuePair<string, object>[]? attachments = null, WriteFlagsEnum flags = (WriteFlagsEnum)(-1))
		{
			var log = new RecordedLog(message, tags ?? Array.Empty<string>(),
				args ?? Array.Empty<object>(), attachments ?? Array.Empty<KeyValuePair<string, object>>(), flags & options.Flags);

			logs.Enqueue(log);
		}

		public override void Dispose()
		{
			base.Dispose();

			timer.Stop();

			buffer.PutInfo(new RecordedPerformance(timer.Elapsed.TotalSeconds, options.Tags, attachments.ToArray(), options.Flags, logs.ToArray()));
		}
	}
}