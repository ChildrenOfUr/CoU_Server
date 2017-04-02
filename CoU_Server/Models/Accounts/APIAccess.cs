using System.ComponentModel.DataAnnotations;

namespace CoU_Server.Models.Accounts {
	public class APIAccess {
		[Required]
		[Key]
		public int ID { get; set; }

		[Required]
		public User User { get; set; }

		[Required]
		public string Token { get; set; }
		
		[Required]
		public int AccessCount { get; set; }
	}
}
