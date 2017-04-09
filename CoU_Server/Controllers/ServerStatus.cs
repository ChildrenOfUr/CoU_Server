using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using System.Diagnostics;

namespace CoU_Server.Controllers {
	[Route("api/[controller]")]
	public class ServerStatus : Controller {
		public static readonly DateTime StartTime = DateTime.Now;

		// GET api/serverStatus
		[HttpGet]
		public Dictionary<string, dynamic> Get() {
			return new Dictionary<string, dynamic> {
				{ "numPlayers", 0 },
				{ "playerList", new string[] { } },
				{ "numStreetsLoaded", 0 },
				{ "streetsLoaded", new Dictionary<string, string> { } },
				{ "bytesUsed", BytesUsed },
				{ "cpuUsed", null }, // TODO: get system CPU usage
				{ "uptime", (DateTime.Now - StartTime).ToString(@"ddd\.hh\:mm\:ss") }
			};
		}

		public long BytesUsed {
			get {
				return Process.GetCurrentProcess().PrivateMemorySize64;
			}
		}
	}
}
