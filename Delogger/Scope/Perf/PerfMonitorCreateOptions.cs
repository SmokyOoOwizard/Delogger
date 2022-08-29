namespace Delogger.Scope.Perf
{
	public class PerfMonitorCreateOptions
	{
		public readonly static PerfMonitorCreateOptions Default = new PerfMonitorCreateOptions();

		public string[]? Tags;
		public WriteFlagsEnum Flags = WriteFlagsEnum.All;
	}
}