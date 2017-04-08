using System;
using System.Collections.Generic;
using Filesystem = System.IO.File;

namespace CoU_Server.Util.Logging {
	public enum LogLevel {
		All = 0,
		Debug = 50,
		Verbose = 100,
		Info = 200,
		Command = 300,
		Warning = 400,
		Error = 500,
		None = 1000
	}

	public static class Settings {
		/// <summary>
		/// Settings stored in memory
		/// </summary>
		private static Dictionary<string, dynamic> L1Cache = new Dictionary<string, dynamic>();

		/// <summary>
		/// Settings stored on disk
		/// </summary>
		private static Dictionary<string, dynamic> L2Cache {
			get {
				string json;

				try {
					json = Filesystem.ReadAllText(File);
					if (String.IsNullOrEmpty(json.Trim())) {
						throw new FormatException();
					}
				} catch {
					json = "{}";
				}

				// TODO: decode JSON
				// return json;
				throw new NotImplementedException();
			}

			set {
				string json;

				try {
					// TODO: encode JSON
					throw new NotImplementedException();
				} catch {
					json = "{}";
				}

				try {
					if (!Filesystem.Exists(File)) {
						Filesystem.Create(File);
					}

					Filesystem.WriteAllText(File, json);
				} catch (Exception ex) {
					Logger.Error("Log config JSON not written", ex);
				}
			}
		}

		/// <summary>
		/// Name of the settings file
		/// </summary>
		private static string File {
			get {
				// TODO: https://github.com/ChildrenOfUr/coUserver/blob/1b412c818232001dbb4e5456f48480a4a6218197/lib/common/log/settings.dart#L111
				return "logsettings.json";
			}
		}

		/// <summary>
		/// Get the value of any setting
		/// </summary>
		/// <param name="setting">Key of the setting</param>
		/// <param name="fallback">Default value of the setting</param>
		/// <returns>Value of the setting</returns>
		public static dynamic Get(string setting, dynamic fallback = null) {
			return L1Cache[setting] ?? L1Cache[setting] ?? fallback;
		}

		/// <summary>
		/// Change the value of any setting
		/// </summary>
		/// <param name="setting">Key of the setting</param>
		/// <param name="value">New value of the setting, or null to delete it</param>
		/// <param name="overwrite">Set to false to only change the setting if it does not have a value</param>
		public static void Set(string setting, dynamic value, bool overwrite = true) {
			if (!overwrite && Get(setting) != null) {
				return;
			}

			if (value != null) {
				// Update setting
				value = value.ToString();
				L1Cache[setting] = value;
				L2Cache[setting] = value;
				L2Cache = new Dictionary<string, dynamic>(L2Cache);
			} else {
				// Clear setting
				L1Cache.Remove(setting);
				L2Cache.Remove(setting);
				L2Cache = new Dictionary<string, dynamic>(L2Cache);
			}
		}
	}
}
