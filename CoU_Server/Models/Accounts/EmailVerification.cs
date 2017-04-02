using System.ComponentModel.DataAnnotations;

namespace CoU_Server.Models.Accounts {
	public class EmailVerification {
		[Required]
		[Key]
		public int ID { get; set; }

		public string Email { get; set; }

		public string Token { get; set; }

		public bool Verified { get; set; }
	}
}
