using Delogger.InformationWorker;
using Delogger.Scope;

namespace Delogger
{
	public sealed class Delogger : IDisposable
	{
		private readonly AbstractInformationProcessWorker pWorker;
		private readonly RecordedInformationBuffer buffer = new();

		public IDScope RootScope { get; private set; }


		public Delogger(AbstractInformationProcessWorker pWorker, bool autoStart = true)
		{
			RootScope = new RootDScope(buffer);

			this.pWorker = pWorker;
			pWorker.SetUp(buffer, RootScope);

			if (autoStart)
			{
				pWorker.Start();
			}
		}

		public void Start()
		{
			if (pWorker.Running)
			{
				return;
			}

			pWorker.Start();
		}

		public void Dispose()
		{
			pWorker.Stop();
		}
	}
}