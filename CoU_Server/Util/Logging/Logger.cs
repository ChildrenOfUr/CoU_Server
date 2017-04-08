using System;

namespace CoU_Server.Util.Logging {
	public static class Logger {
		/// <summary>
		/// Set default logger settings to fill any missing settings
		/// </summary>
		public static void Init() {
			Settings.Set("Colors", false, overwrite: false);
			Settings.Set("Errors", true, overwrite: false);
			Settings.Set("Level", LogLevel.All, overwrite: false);
			Settings.Set("SkipLines", 0, overwrite: false);
			Settings.Set("StackTraces", true, overwrite: false);
		}

		/// <summary>
		/// Print a message to the console (if enabled)
		/// </summary>
		/// <param name="obj">Object to print</param>
		/// <param name="level">Log level of the message</param>
		/// <param name="error">Error causing the message to be printed</param>
		/// <returns>The formatted message that was printed</returns>
		public static string Log(dynamic obj, LogLevel level = LogLevel.Info, Exception error = null) {
			// Timestamp
			string timestamp = DateTime.Now.ToString().PadRight(26, '0');

			// Message format
			string message = $"[{level} ({timestamp})] {obj}";

			// Print error if enabled and applicable
			if ((bool) Settings.Get("Errors", fallback: false) && error != null) {
				message += $"\n{error}";
			}

			// Print stack traces if enabled and applicable
			if ((bool) Settings.Get("StackTraces", fallback: false) && error.StackTrace != null) {
				message += $"\n{error.StackTrace}";
			}

			// Remove trailing whitespace (from errors and stack traces)
			message = message.TrimEnd();

			// Apply colors if enabled
			if ((bool) Settings.Get("Colors", fallback: false)) {
				message = AnsiColors.Color(message, AnsiColors.GetColor(level));
			}

			// Print to console if we are logging this level
			if (level >= (LogLevel) Settings.Get("Level", fallback: LogLevel.All)) {
				string blankLines = new String('\n', Settings.Get("SkipLines", fallback: 0));
				Console.WriteLine(message + blankLines);
			}

			// Return formatted string
			return message;
		}

		/// <summary>
		/// Log only if testing
		/// </summary>
		/// <param name="obj">Object to print</param>
		/// <param name="error">Error causing the message to be printed</param>
		/// <returns></returns>
		public static string Debug(dynamic obj, Exception error = null) {
			return Log(obj, LogLevel.Debug, error);
		}

		/// <summary>
		/// Log spam or a fine status message to the console
		/// </summary>
		/// <param name="obj">Object to print</param>
		/// <returns></returns>
		public static string Verbose(dynamic obj) {
			return Log(obj, LogLevel.Verbose);
		}

		/// <summary>
		/// Log an informational message to the console
		/// </summary>
		/// <param name="obj">Object to print</param>
		/// <returns></returns>
		public static string Info(dynamic obj) {
			return Log(obj, LogLevel.Info);
		}

		/// <summary>
		/// Log command output to the console
		/// </summary>
		/// <param name="obj">Object to print</param>
		/// <returns></returns>
		public static string Command(dynamic obj) {
			return Log(obj, LogLevel.Command);
		}

		/// <summary>
		/// Log a warning and maybe an exception to the console
		/// </summary>
		/// <param name="obj">Object to print</param>
		/// <param name="error">Error causing the message to be printed</param>
		/// <returns></returns>
		public static string Warning(dynamic obj, Exception error = null) {
			return Log(obj, LogLevel.Warning);
		}

		/// <summary>
		/// Log an error message and maybe an exception to the console
		/// </summary>
		/// <param name="obj">Object to print</param>
		/// <param name="error">Error causing the message to be printed</param>
		/// <returns></returns>
		public static string Error(dynamic obj, Exception error = null) {
			return Log(obj, LogLevel.Error, error);
		}
	}

	public static class LogLevelExtensions {
		/// <summary>
		/// Remove the enum name prefix from an enum string representation
		/// </summary>
		/// <param name="level">Log level enum value</param>
		/// <returns>Name of the enum value</returns>
		public static string ToString(this LogLevel level) {
			string name = level.ToString().Split('.')[1];
			return name.PadRight(7);
		}
	}
}
