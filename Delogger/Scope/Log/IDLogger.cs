namespace Delogger.Scope.Log
{
	public interface IDLogger : IDisposable
	{
		void Log(string message, string[]? tags = null, object[]? args = null, KeyValuePair<string, object>[]? attachments = null, WriteFlagsEnum flags = WriteFlagsEnum.All);
	}
}