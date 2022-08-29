namespace Delogger.InformationWorker
{
	public class ThreadedInformationProcessWorker : AbstractInformationProcessWorker
	{
		private readonly Thread thread;

		public ThreadedInformationProcessWorker() : base()
		{
			thread = new Thread(threadWork);
		}

		protected override void StartInternal()
		{
			thread.Start();
		}

		protected override void StopInternal()
		{
			thread.Join();
		}

		private void threadWork()
		{
			while (Running)
			{
				var processedCount = ProcessWork();
				if (processedCount == 0)
				{
					Thread.Sleep(10);
				}
			}
		}
	}
}