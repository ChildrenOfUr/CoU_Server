using System.ComponentModel.DataAnnotations;

namespace CoU_Server.Models {
	public class UserQuest {
		[Required]
		[Key]
		public int ID { get; set; }

		[Required]
		public User User { get; set; }

		public string CompletedList { get; set; }

		public string InProgressList { get; set; }
	}
}
