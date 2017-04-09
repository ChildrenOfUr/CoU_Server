using CoU_Server.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoU_Server.Models.Streets.MapData {
	public static class MapData {
		private static Dictionary<string, Dictionary<string, dynamic>> HubsData, StreetsData;
		private static Dictionary<string, Dictionary<string, Dictionary<string, dynamic>>> RenderData;

		public static Dictionary<string, Dictionary<string, dynamic>> Hubs {
			get {
				return new Dictionary<string, Dictionary<string, dynamic>>(HubsData);
			}
		}

		public static Dictionary<string, Dictionary<string, dynamic>> Streets {
			get {
				return new Dictionary<string, Dictionary<string, dynamic>>(StreetsData);
			}
		}

		public static Task Load() {
			// TODO: Load from JSON https://github.com/ChildrenOfUr/coUserver/blob/dev/lib/common/mapdata/mapdata.dart#L23
			HubsData = new Dictionary<string, Dictionary<string, dynamic>>();
			StreetsData = new Dictionary<string, Dictionary<string, dynamic>>();
			RenderData = new Dictionary<string, Dictionary<string, Dictionary<string, dynamic>>>();
			throw new NotImplementedException();
		}

		/// <summary>
		/// Find a street by TSID 
		/// </summary>
		/// <param name="tsid">TSID (either G or L form)</param>
		/// <returns>Street data</returns>
		public static Dictionary<string, dynamic> GetStreetByTsid(string tsid) {
			tsid = tsid.TsidL();
			var street = from s in Streets.Values
						 where s["tsid"] != null && s["tsid"].TsidL() == tsid.TsidL()
						 select s;
			return street.SingleOrDefault() ?? GetStreetFile(tsid);
		}

		/// <summary>
		/// Find a street by name/label
		/// </summary>
		/// <param name="name">Street label</param>
		/// <returns>Street data</returns>
		public static Dictionary<string, dynamic> GetStreetByName(string name) {
			return Streets[name];
		}

		/// <summary>
		/// List all streets in a hub
		/// </summary>
		/// <param name="hubId">ID of the hub (int or string)</param>
		/// <returns>A list of the streets' data</returns>
		public static List<Dictionary<string, dynamic>> GetStreetsInHub(dynamic hubId) {
			hubId = hubId.ToString();

			return (from s in Streets.Values
					where s["hub_id"] != null && s["hub_id"].ToString() == hubId
					select s).ToList();
		}

		public static Dictionary<string, dynamic> GetStreetFile(string tsid) {
			// TODO: https://github.com/ChildrenOfUr/coUserver/blob/dev/lib/common/mapdata/mapdata.dart#L89
			throw new NotImplementedException();
		}

		/// <summary>
		/// Checks whether a street is hidden
		/// </summary>
		/// <param name="label">Label/name of the street to check</param>
		/// <returns>True if hidden, false if not</returns>
		public static bool IsStreetHidden(string label) {
			try {
				Dictionary<string, dynamic> street = Streets[label];

				// Street level
				if (street["map_hidden"]) {
					return true;
				}

				// Hub level
				if (Hubs[street["hub_id"]]["map_hidden"]) {
					return true;
				}

				// Not hidden
				return false;
			} catch {
				// Not sure
				return false;
			}
		}
	}
}
