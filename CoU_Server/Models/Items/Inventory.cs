using CoU_Server.Models.Accounts;
using System.ComponentModel.DataAnnotations;

namespace CoU_Server.Models.Items {
	public class Inventory {
		[Required]
		[Key]
		public int ID { get; set; }

		[Required]
		public string Json { get; set; }

		[Key]
		public User User { get; set; }
	}
}
