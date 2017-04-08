using CoU_Server.Util.Logging;

namespace CoU_Server.Util {
	public static class Util {
	}

	public static class StringExtensions {
		/// <summary>
		/// Capitalize the first letter of a string
		/// </summary>
		/// <param name="str">The string</param>
		/// <returns>The string with the first letter capitalized</returns>
		public static string UpperFirst(this string str) {
			return str.Substring(0, 1).ToUpper() + str.Substring(1);
		}

		/// <summary>
		/// Get a TSID in "L..." (Tiny Speck) form
		/// </summary>
		/// <param name="tsid">TSID</param>
		/// <returns>TSID</returns>
		public static string TsidL(this string tsid) {
			if (tsid == null) {
				Logger.Warning($"Cannot convert {tsid} to L/TS form");
				return tsid;
			}

			if (tsid.StartsWith("G")) {
				// In CAT422 form
				return "L" + tsid.Substring(1);
			} else {
				// Assume in TS form
				return tsid;
			}
		}

		/// <summary>
		/// Get a TSID in "G..." (CAT422) form
		/// </summary>
		/// <param name="tsid">TSID</param>
		/// <returns>TSID</returns>
		public static string TsidG(this string tsid) {
			if (tsid == null) {
				Logger.Warning($"Cannot convert {tsid} to G/CAT422 form");
				return tsid;
			}

			if (tsid.StartsWith("L")) {
				// In TS form
				return "G" + tsid.Substring(1);
			} else {
				// Assume in CAT422 form
				return tsid;
			}
		}

		/// <summary>
		/// Convert "CamelCase" to "Space Case"
		/// </summary>
		/// <param name="camelCase">Camel case</param>
		/// <returns>Space case</returns>
		public static string SplitCamelCase(this string camelCase) {
			string spaceCase = "";

			for (int c = 0; c < camelCase.Length; c++) {
				spaceCase += camelCase[c];

				if (
					// Not at end
					c < camelCase.Length - 1 &&
					// Next letter is uppercase
					camelCase[c + 1].ToUpper() == camelCase[c + 1]
				) {
					spaceCase += " ";
				}
			}

			return spaceCase;
		}
	}

	public static class CharExtensions {
		/// <summary>
		/// Convert a character to upper case
		/// </summary>
		/// <param name="c">Character</param>
		/// <returns>Uppercase character</returns>
		public static char ToUpper(this char c) {
			return c.ToString().ToUpper()[0];
		}

		/// <summary>
		/// Converts a character to lower case
		/// </summary>
		/// <param name="c">Character</param>
		/// <returns>Lowercase character</returns>
		public static char ToLower(this char c) {
			return c.ToString().ToLower()[0];
		}
	}
}
