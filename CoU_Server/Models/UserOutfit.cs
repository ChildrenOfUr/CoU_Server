using CoU_Server.Models.Accounts;
using System.ComponentModel.DataAnnotations;

namespace CoU_Server.Models {
	public class UserOutfit {
		[Required]
		[Key]
		public int ID { get; set; }

		public User User { get; set; }

		[Required]
		public string Head { get; set; }

		[Required]
		public string LeftLeg { get; set; }

		[Required]
		public string RightLeg { get; set; }

		[Required]
		public string LeftArm { get; set; }

		[Required]
		public string RightArm { get; set; }
	}
}
