using Delogger.Extensions;
using System.Text;

namespace Delogger.Scope.Log
{
	internal class RecordedLog : IRecordedInformation
	{
		public WriteFlagsEnum Flags { get; private set; }
		public string[] Tags { get; private set; }
		public IRecordedInformation[] SubInfo { get; private set; }
		public KeyValuePair<string, string>[] Attachments { get; private set; }


		public readonly string Message;
		public readonly object[] Args;


		public RecordedLog(string message, string[] tags, object[] args, KeyValuePair<string, object>[] attachments, WriteFlagsEnum flags, IRecordedInformation[]? subInfo = null)
		{
			Message = message;
			Tags = tags;
			Args = args;
			Flags = flags;
			Attachments = attachments.Select(x => new KeyValuePair<string, string>(x.Key, x.Value?.ToString() ?? "null")).ToArray();
			SubInfo = subInfo ?? Array.Empty<IRecordedInformation>();
		}

		public string ToStringF(bool withColor)
		{
			var sb = new StringBuilder($"[{DateTime.Now.ToString("dd.MM.yyyy")} {DateTime.Now.ToString("HH:mm:ss.fff")}]");

			if (Tags?.Length > 0)
			{
				sb.Append(RecordedInformationExtensions.ColorizeTags(Tags));
			}

			sb.Append($": {Message.SafeFormat(Args ?? Array.Empty<object>())}");

			sb.Append(RecordedInformationExtensions.FromatSubInfoAndAttachments(withColor, SubInfo, Attachments));

			return sb.ToString();
		}
	}
}