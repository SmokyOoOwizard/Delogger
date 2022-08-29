using Delogger.Extensions;
using System.Text;

namespace Delogger.Scope.Perf
{
	internal class RecordedPerformance : IRecordedInformation
	{
		public WriteFlagsEnum Flags { get; private set; }
		public string[] Tags { get; private set; }
		public IRecordedInformation[] SubInfo { get; private set; }
		public KeyValuePair<string, string>[] Attachments { get; private set; }

		public double Time { get; private set; }


		public RecordedPerformance(double time, string[]? tags = null, KeyValuePair<string, string>[]? attachments = null, WriteFlagsEnum flags = WriteFlagsEnum.All, IRecordedInformation[]? subInfo = null)
		{
			Flags = flags;
			Tags = tags ?? Array.Empty<string>();
			Time = time;
			Attachments = attachments ?? Array.Empty<KeyValuePair<string, string>>();
			SubInfo = subInfo ?? Array.Empty<IRecordedInformation>();
		}

		public string ToStringF(bool withColor)
		{
			var sb = new StringBuilder($"[{DateTime.Now.ToString("dd.MM.yyyy")} {DateTime.Now.ToString("HH:mm:ss.fff")}]");

			if (Tags?.Length > 0)
			{
				sb.Append(RecordedInformationExtensions.ColorizeTags(Tags));
			}

			sb.Append($" Perf: {Time}");

			sb.Append(RecordedInformationExtensions.FromatSubInfoAndAttachments(withColor, SubInfo, Attachments));

			return sb.ToString();
		}
	}
}