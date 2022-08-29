using Delogger.Scope.Log;

namespace Delogger
{
	internal interface IRecordedInformation
	{
		WriteFlagsEnum Flags { get; }
		string[] Tags { get; }

		IRecordedInformation[] SubInfo { get; }
		KeyValuePair<string, string>[] Attachments { get; }

		string ToStringF(bool withColor);
	}
}