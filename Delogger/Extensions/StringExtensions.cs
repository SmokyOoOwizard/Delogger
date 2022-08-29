using System.Text.RegularExpressions;
using System;

namespace Delogger.Extensions
{
	public static class StringExtensions
	{
		public static string SafeFormat(this string value, params object[] args)
		{
			var pattern = @"{(.*?)}";
			var matches = Regex.Matches(value, pattern);
			var matchCount = matches.Count;
			if (matchCount > args.Length)
			{
				var argsExtended = args.ToList();
				for (int i = args.Length; i < matchCount; i++)
				{
					argsExtended.Add($"{{{i}}}"); //Can add null value to erase them
				}
				return string.Format(value, argsExtended.ToArray());
			}
			return string.Format(value, args);
		}

		internal static string ReplaceLast(this string text, string search, string replace)
		{
			int pos = text.LastIndexOf(search);
			if (pos < 0)
			{
				return text;
			}
			return string.Concat(text.AsSpan(0, pos), replace, text.AsSpan(pos + search.Length));
		}
	}
}