namespace Delogger
{
	internal interface IInformationBufferReader
	{
		int Read(ref IRecordedInformation[] buffer, int offset, int count);
	}
}