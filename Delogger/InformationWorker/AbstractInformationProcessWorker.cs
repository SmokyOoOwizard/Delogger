using Delogger.Extensions;
using Delogger.Scope;
using Delogger.Scope.Log;

namespace Delogger.InformationWorker
{
	public abstract class AbstractInformationProcessWorker
	{
		public const int BUFFER_SIZE = 1000;

		private IRecordedInformation[] infoBuffer;
		private readonly int bufferSize;
		private IInformationBufferReader buffer;

		protected IDLogger Logger { get; private set; }
		public bool Running { get; private set; }


#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
		public AbstractInformationProcessWorker(int bufferSize = BUFFER_SIZE)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
		{
			this.bufferSize = bufferSize;

			infoBuffer = new IRecordedInformation[bufferSize];
		}

		internal void SetUp(IInformationBufferReader buffer, IDScope scope)
		{
			this.buffer = buffer;
			Logger = scope.CreateLogger();
		}

		public void Start()
		{
			if (Running)
			{
				return;
			}
			Running = true;

			StartInternal();
		}

		protected abstract void StartInternal();

		public void Stop()
		{
			if (!Running)
			{
				return;
			}
			Running = false;

			StopInternal();
		}
		protected abstract void StopInternal();

		/// <returns>Processed info count</returns>
		protected int ProcessWork()
		{
			try
			{
				// TODO possibly lost info. if something throw exception we lost all buffer
				var readed = buffer.Read(ref infoBuffer, 0, infoBuffer.Length);
				if (readed == 0)
				{
					return 0;
				}

				//
				for (int i = 0; i < readed; i++)
				{
					var info = infoBuffer[i];

					if (info.Flags.HasFlag(WriteFlagsEnum.Verbose))
					{
						ConsoleExtensions.WriteLineColor(info.ToStringF(true));
					}
				}
				//

				return readed;
			}
			catch (Exception ex)
			{
				Logger.LogException(ex);
			}
			return 0;
		}
	}
}