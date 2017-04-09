using CoU_Server.Models.Accounts;
using System;
using System.ComponentModel.DataAnnotations;

namespace CoU_Server.Models {
	public class Note {
		[Required]
		[Key]
		public int ID { get; set; }

		[Required]
		public string Title { get; set; }

		[Required]
		public string Body { get; set; }

		[Required]
		public DateTime Timestamp { get; set; }

		[Required]
		[Key]
		public User User { get; set; }
	}
}
