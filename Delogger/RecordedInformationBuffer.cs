using System.Collections.Concurrent;

namespace Delogger
{
	internal class RecordedInformationBuffer : IInformationBufferWriter, IInformationBufferReader
	{
		private readonly ConcurrentQueue<IRecordedInformation> records = new();

		public void PutInfo(IRecordedInformation info)
		{
			records.Enqueue(info);
		}

		public int Read(ref IRecordedInformation[] buffer, int offset, int count)
		{
			for (int i = 0; i < count; i++)
			{
				if (records.TryDequeue(out var item))
				{
					buffer[offset + i] = item;
				}
				else
				{
					return i;
				}
			}
			return count;
		}
	}
}