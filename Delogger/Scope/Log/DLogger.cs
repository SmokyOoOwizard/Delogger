namespace Delogger.Scope.Log
{
	internal class DLogger : DScope, IDLogger
	{
		private readonly LoggerCreateOptions options;

		public DLogger(IDScope parent, IInformationBufferWriter buffer, LoggerCreateOptions options) : base(parent, buffer)
		{
			this.options = options;
		}

		public void Log(string message, string[]? tags = null, object[]? args = null, KeyValuePair<string, object>[]? attachments = null, WriteFlagsEnum flags = (WriteFlagsEnum)(-1))
		{
			if (tags == null)
			{
				tags = Array.Empty<string>();
			}
			if (options.Tags != null)
			{
				tags = tags.Union(options.Tags).ToArray();
			}


			var log = new RecordedLog(message, tags, args ?? Array.Empty<object>(), attachments ?? Array.Empty<KeyValuePair<string, object>>(), flags & options.Flags);

			buffer.PutInfo(log);
		}
	}
}