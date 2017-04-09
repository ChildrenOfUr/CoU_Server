using CoU_Server.Models.Accounts;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CoU_Server.Models {
	public class Metabolics {
		[Required]
		[Key]
		public int ID { get; set; }

		[Key]
		public User User { get; set; }

		[Required]
		public int Img { get; set; }

		[Required]
		public int LifetimeImg { get; set; }

		[Required]
		public int Currants { get; set; }

		[Required]
		public int Mood { get; set; }

		public int MaxMood { get; set; }

		[Required]
		public int Energy { get; set; }

		public int MaxEnergy { get; set; }

		public string CurrentStreet { get; set; }

		public int CurrentStreetX { get; set; }

		public int CurrentStreetY { get; set; }

		public string LastStreet { get; set; }

		public string UndeadStreet { get; set; }

		public int AlphFavor { get; set; }

		public int CosmaFavor { get; set; }

		public int FriendlyFavor { get; set; }

		public int GrendalineFavor { get; set; }

		public int HumbabaFavor { get; set; }

		public int LemFavor { get; set; }

		public int MabFavor { get; set; }

		public int PotFavor { get; set; }

		public int SprigganFavor { get; set; }

		public int TiiFavor { get; set; }

		public int ZilleFavor { get; set; }

		public int MaxAlphFavor { get; set; }

		public int MaxCosmaFavor { get; set; }

		public int MaxFriendlyFavor { get; set; }

		public int MaxGrendalineFavor { get; set; }

		public int MaxHumbabaFavor { get; set; }

		public int MaxLemFavor { get; set; }

		public int MaxMabFavor { get; set; }

		public int MaxPotFavor { get; set; }

		public int MaxSprigganFavor { get; set; }

		public int MaxTiiFavor { get; set; }

		public int MaxZilleFavor { get; set; }

		public List<string> LocationHistory { get; set; }

		public int QuoinsCollected { get; set; }

		public decimal QuoinMultiplier { get; set; }

		public string Skills { get; set; }

		public string Buffs { get; set; }
	}
}
