using System.Collections.Generic;

namespace CoU_Server.Util.Logging {
	public static class AnsiColors {
		/// <summary>
		/// Format the given text in a color
		/// </summary>
		/// <param name="text">Text to format</param>
		/// <param name="color">ANSI color format</param>
		/// <returns>ANSI output</returns>
		public static string Color(string text, string color) {
			return color + text + color;
		}

		/// <summary>
		/// Get color by LogLevel
		/// </summary>
		/// <param name="level">Log level to get the color for</param>
		/// <returns>ANSI color format</returns>
		public static string GetColor(LogLevel level) {
			return new Dictionary<LogLevel, string> {
				{ LogLevel.Debug, Blue },
				{ LogLevel.Verbose, Green },
				{ LogLevel.Info, Cyan },
				{ LogLevel.Command, Purple },
				{ LogLevel.Warning, Yellow },
				{ LogLevel.Error, Red }
			}[level] ?? Clear;
		}

		/// <summary>
		/// Reset sequence
		/// </summary>
		public static string Clear {
			get { return Escape(0); }
		}

		/// <summary>
		/// Blue sequence
		/// </summary>
		public static string Blue {
			get { return Escape(34); }
		}

		/// <summary>
		/// Green sequence
		/// </summary>
		public static string Green {
			get { return Escape(32); }
		}

		/// <summary>
		/// Cyan sequence
		/// </summary>
		public static string Cyan {
			get { return Escape(36); }
		}

		/// <summary>
		/// Purple sequence
		/// </summary>
		public static string Purple {
			get { return Escape(35); }
		}

		/// <summary>
		/// Yellow sequence
		/// </summary>
		public static string Yellow {
			get { return Escape(33); }
		}

		/// <summary>
		/// Red sequence
		/// </summary>
		public static string Red {
			get { return Escape(31); }
		}

		/// <summary>
		/// Escape a color code
		/// </summary>
		/// <param name="color">Color code to escape</param>
		/// <returns>Escaped color code</returns>
		private static string Escape(int color) {
			return $@"\x1B[{color}m";
		}
	}
}
