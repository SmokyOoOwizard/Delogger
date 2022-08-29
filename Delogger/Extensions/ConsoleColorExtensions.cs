namespace Delogger.Extensions
{
	public static class ConsoleColorExtensions
	{
		public static string ToStringCode(this ConsoleColor? color)
		{
			return $"@[[{color}]]";
		}
	}
}