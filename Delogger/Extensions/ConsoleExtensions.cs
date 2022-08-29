using System.Text.RegularExpressions;

namespace Delogger.Extensions
{
	public static class ConsoleExtensions
	{
		// usage: WriteColor("This is my @[[message]] with inline @[[color]] changes.", ConsoleColor.Yellow);
		public static void WriteLineColor(string line)
		{
			var pieces = Regex.Split(line, @"(@\[\[[^\]]*\]\])");

			ConsoleColor originColor = Console.ForegroundColor;
			for (int i = 0; i < pieces.Length; i++)
			{
				string piece = pieces[i];

				if (piece.StartsWith("@[[") && piece.EndsWith("]]"))
				{
					piece = piece[3..^2];
					if (Enum.TryParse<ConsoleColor>(piece, out var color))
					{
						Console.ForegroundColor = color;
					}
					else if (piece == "RESET")
					{
						Console.ForegroundColor = originColor;
					}
				}
				else
				{
					Console.Write(piece);
				}
			}

			Console.WriteLine();
			Console.ResetColor();
		}
	}
}