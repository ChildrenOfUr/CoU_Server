using System;
using System.ComponentModel.DataAnnotations;

namespace CoU_Server.Models {
	public class Auction {
		[Required]
		[Key]
		public int ID { get; set; }

		[Required]
		public string ItemName { get; set; }

		[Required]
		public int ItemCount { get; set; }

		[Required]
		public int TotalCost { get; set; }

		[Required]
		public User User { get; set; }

		[Required]
		public DateTime StartTime { get; set; }

		[Required]
		public DateTime EndTime { get; set; }
	}
}
