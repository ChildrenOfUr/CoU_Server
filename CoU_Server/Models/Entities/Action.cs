using System.Collections.Generic;

namespace CoU_Server.Models.Entities {
	public class Action {
		public string Name { get; set; }

		public string Description { get; set; }

		public string Error { get; set; }

		private string Word { get; set; }

		public bool Enabled { get; set; }

		public bool MultiEnabled { get; set; }

		public bool GroundAction { get; set; }

		public int TimeRequired { get; set; }

		public ItemRequirements ItemRequirements { get; set; }

		public SkillRequirements SkillRequirements { get; set; }

		public EnergyRequirements EnergyRequirements { get; set; }

		public string AssociatedSkill { get; set; }

		public Action() { }

		public Action(string name) {
			Name = name;
		}

		public string ActionWord {
			get {
				return ActionWord ?? Name.ToLower();
			}

			set {
				Word = value;
			}
		}

		public override string ToString() {
			string str = $"{Name} requires any of {ItemRequirements.Any}, all of {ItemRequirements.All} and at least ";

			foreach (string skill in SkillRequirements.RequiredSkillLevels.Keys) {
				str += $"{SkillRequirements.RequiredSkillLevels[skill]} level of {skill}, ";
			}

			str = str.Substring(0, str.Length - 2);

			return str;
		}
	}

	public struct SkillRequirements {
		public Dictionary<string, int> RequiredSkillLevels { get; set; }

		public string Error {
			get {
				return "You don't have the required skill(s)";
			}
		}
	}

	public struct ItemRequirements {
		public List<string> Any { get; set; }

		public Dictionary<string, int> All { get; set; }

		public string Error {
			get {
				return "You don't have the required item(s)";
			}
		}
	}

	public struct EnergyRequirements {
		public int Amount { get; set; }

		public string Error { 
			get {
				return $"You need at least {Amount} energy to perform this action";
			}
		}
	}
}
