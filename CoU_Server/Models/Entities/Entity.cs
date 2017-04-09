using CoU_Server.Models.Entities.StreetEntities;
using CoU_Server.Models.Streets.MapData;
using CoU_Server.Util;
using CoU_Server.Util.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoU_Server.Models.Entities {
	public interface IPersistable {
		StreetEntity Persist();
		void RestoreState(Dictionary<string, string> metadata);
		Dictionary<string, string> GetPersistMetadata();
	}

	public interface IActionable {
		Task<List<Action>> CustomizeActions(string email);
	}

	public abstract class Entity : IPersistable, IActionable {
		public static string CreateId(double x, double y, String type, String tsid) {
			int hash = (type + x.ToString() + y.ToString() + tsid.TsidL()).GetHashCode();
			return type.Substring(0, 1) + hash.ToString();
		}

		public List<Action> Actions = new List<Action>();
		public int ActionTime = 2500;
		public double X, Y, Z, Rotation;
		public bool HFlip;
		public string StreetName, Type, ID;
		public string BubbleText;
		public DateTime SayTimeout;

		protected Dictionary<string, List<string>> Responses = new Dictionary<string, List<string>>();
		protected Dictionary<string, Spritesheet> States;
		protected Spritesheet CurrentState;
		protected DateTime Respawn;

		public StreetEntity Persist() {
			Dictionary<string, dynamic> streetData = MapData.GetStreetByName(StreetName);
			if (streetData == null) {
				Logger.Error($"Cannot persist entity {ID} ({Type}) because streetData was null on {StreetName}");
				return null;
			}

			string tsid = streetData["tsid"];
			if (tsid == null) {
				Logger.Error($"Cannot persist entity {ID} ({Type}) because tsid is null on {StreetName}");
			}

			return new StreetEntity{
				ID = ID, 
				Type = Type,
				TSID = tsid,
				X = X,
				Y = Y,
				Z = Z,
				Rotation = Rotation,
				HFlip = HFlip,
				Metadata = GetPersistMetadata()
			};
		}

		public abstract void RestoreState(Dictionary<string, string> metadata);

		public Dictionary<string, string> GetPersistMetadata() {
			return new Dictionary<string, string>();
		}

		public Task<List<Action>> CustomizeActions(string email) {
			return Task.FromResult(Actions);
		}

		/// <summary>
		/// Display text in a bubble
		/// </summary>
		/// <param name="message">Text to display</param>
		public void Say(string message = "") {
			message = message.Trim();

			DateTime now = DateTime.Now;

			if (SayTimeout == null && SayTimeout.CompareTo(now) < 0) {
				BubbleText = message;
				int ttl = message.Length * 30 + 3000; // 0.3 sec per character plus 3 seconds minimum
				ttl = Math.Min(ttl, 10000); // Cap at 10 seconds

				TimeSpan duration = new TimeSpan(0, 0, 0, 0, milliseconds: ttl);
				SayTimeout = now.Add(duration);

				Task.Run(async () => {
					await Task.Delay(duration);
					BubbleText = null;
					// TODO: ResetGains();
				});
			}
		}

		/// <summary>
		/// Update the appearance
		/// </summary>
		/// <param name="state">New state</param>
		/// <param name="repeat">How many times to loop</param>
		/// <param name="repeatFor">How long to loop</param>
		/// <param name="thenState">State to change to once this one is complete</param>
		public void SetState(string state, int repeat = 1, TimeSpan? repeatFor = null, string thenState = null) {
			if (!States.ContainsKey(state)) {
				throw new Exception($"You made a typo. {state} does not exist in the states array for {GetType()}");
			}

			if (thenState != null && !States.ContainsKey(thenState)) {
				throw new Exception($"You made a typo. {thenState} does not exist in the states array for {GetType()}");
			}

			CurrentState = States[state];

			int length;
			if (repeatFor.HasValue) {
				length = repeatFor.Value.Milliseconds;
			} else {
				// If we want the animation to play more than once before respawn, multiply the length by the repeat
				length = (CurrentState.NumFrames / 30 * 1000) * repeat;
			}

			if (thenState != null) {
				length += States[thenState].NumFrames / 30 * 1000;

				Task.Run(async () => {
					await Task.Delay(length);
					SetState(thenState);
				});
			}

			Respawn = DateTime.Now.Add(new TimeSpan(0, 0, 0, 0, milliseconds: length));
		}

		/// <summary>
		/// Check the various requirements for an action to be allowed to be performed
		/// </summary>
		/// <param name="actionName">Name of the action to test for</param>
		/// <param name="email">User's email address</param>
		/// <param name="includeBroken">Whether to count broken tools as tools</param>
		/// <param name="testEnergy">Will be skipped by default since most actions will check this through trySetMetabolics anyway</param>
		/// <returns></returns>
		public Task<bool> HasRequirements(string actionName, string email, bool includeBroken = false, bool testEnergy = false) {
			Action action = Actions.Where(a => a.Name == actionName).Single();
			bool hasRequirements = true;

			// Check that the player has the necessary energy
			if (testEnergy) {
				// TODO: metabolics
				/*
					Metabolics m = await getMetabolics(email: email);
					if (m.energy < action.energyRequirements.energyAmount) {
						return false;
					}
				*/
			}

			// Check the players skill level(s) against the required skill level(s)
			foreach (string skill in action.SkillRequirements.RequiredSkillLevels.Keys) {
				if (!hasRequirements) {
					break;
				}

				int reqSkillLevel = action.SkillRequirements.RequiredSkillLevels[skill];
				int haveLevel = 0; /* await SkillManager.getLevel(skillName, email); */ // TODO: skills
				if (haveLevel < reqSkillLevel) {
					hasRequirements = false;
				}
			}

			// Possibly exit early
			if (!hasRequirements) {
				return Task.FromResult(false);
			}

			// Check that the player has the necessary item(s)
			bool hasAtLeast1 = action.ItemRequirements.Any.Count == 0;
			foreach (string item in action.ItemRequirements.Any) {
				if (hasAtLeast1) {
					break;
				}

				if (includeBroken) {
					hasAtLeast1 = false; /* await InventoryV2.hasItem(email, itemType, 1) */ // TODO: inventory
				} else {
					hasAtLeast1 = false; /* await InventoryV2.hasUnbrokenItem(email, itemType, 1, notifyIfBroken: true) */ // TODO: inventory
				}
			}

			// Possibly exit early
			if (!hasAtLeast1) {
				return Task.FromResult(false);
			}

			foreach (string item in action.ItemRequirements.All.Keys) {
				int needed = action.ItemRequirements.All[item];

				if (includeBroken) {
					hasRequirements = false; /* await InventoryV2.hasItem(email, itemType, numNeeded) */ // TODO: inventory
				} else {
					hasRequirements = false; /* await InventoryV2.hasUnbrokenItem(email, itemType, numNeeded, notifyIfBroken: true) */ // TODO: inventory
				}
			}

			return Task.FromResult(hasRequirements);
		}
	}
}
