using CoU_Server.Models.Accounts;
using System;
using System.ComponentModel.DataAnnotations;

namespace CoU_Server.Models {
	public class MailMessage {
		[Required]
		[Key]
		public string ID { get; set; }

		[Required]
		public User ToUser { get; set; }

		[Required]
		public User FromUser { get; set; }

		[Required]
		public string Subject { get; set; }

		[Required]
		public string Body { get; set; }

		public DateTime Sent { get; set; }

		public int Currants { get; set; }

		public bool CurrantsTaken { get; set; }

		public string Item1 { get; set; }

		public string Item2 { get; set; }

		public string Item3 { get; set; }

		public string Item4 { get; set; }
		
		public string Item5 { get; set; }

		public bool Item1Taken { get; set; }

		public bool Item2Taken { get; set; }

		public bool Item3Taken { get; set; }

		public bool Item4Taken { get; set; }

		public bool Item5Taken { get; set; }
	}
}
