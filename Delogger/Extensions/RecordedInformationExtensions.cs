using System.Text;

namespace Delogger.Extensions
{
	internal static class RecordedInformationExtensions
	{
		public static string ColorizeTags(string[] tags)
		{
			var sb = new StringBuilder();

			if (tags?.Length > 0)
			{
				sb.Append('[');
				for (int i = 0; i < tags?.Length; i++)
				{
					var tag = tags[i];
					var tagLower = tag.ToLower();

					ConsoleColor? currentColor = null;
					switch (tagLower)
					{
						case "debug":
							currentColor = ConsoleColor.DarkYellow;
							break;
						case "warning":
							currentColor = ConsoleColor.Yellow;
							break;
						case "error":
							currentColor = ConsoleColor.Red;
							break;
						case "critical":
							currentColor = ConsoleColor.DarkRed;
							break;
					}
					if (currentColor != null)
					{
						sb.Append(currentColor.ToStringCode());
					}
					sb.Append(tag);

					// reset color
					if (currentColor != null)
					{
						sb.Append("@[[RESET]]");
					}

					if (i + 1 < tags?.Length)
					{
						sb.Append(',');
					}
				}
				sb.Append(']');
			}
			return sb.ToString();
		}

		public static string FromatSubInfoAndAttachments(bool withColor, IRecordedInformation[] subInfo, KeyValuePair<string, string>[] attachments)
		{
			var subSb = new StringBuilder();
			subSb.Append('\n');

			if (attachments.Length > 0)
			{
				subSb.AppendJoin('\n', attachments.Select(x => $"{x.Key}: {x.Value}"));
				subSb.AppendLine();
			}

			subSb.AppendJoin('\n', subInfo.Select(x => x.ToStringF(withColor)));

			var subString = subSb.ToString();

			if (!string.IsNullOrWhiteSpace(subString))
			{
				subString = subString.Replace("\n", "\n│");
				subString = subString.ReplaceLast("\n│", "\n└");
				return subString;
			}
			return "";
		}
	}
}