namespace Delogger.Scope.Log
{
	public class LoggerCreateOptions
	{
		public readonly static LoggerCreateOptions Default = new LoggerCreateOptions();

		public string[]? Tags;
		public WriteFlagsEnum Flags = WriteFlagsEnum.All;
	}
}