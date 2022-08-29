namespace Delogger
{
	[Flags]
	public enum WriteFlagsEnum
	{
		None = 0,
		Verbose = 1 << 0,
		//WriteLocaly = 1 << 1,
		//WriteRemote = 1 << 2,
		All = ~0
	}
}