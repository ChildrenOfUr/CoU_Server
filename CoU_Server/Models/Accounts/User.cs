using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CoU_Server.Models.Accounts {
	public class User {
		[Key]
		[Required]
		public int ID { get; set; }
		
		[Required]
		[StringLength(30)]
		public string Username { get; set; }

		[Required]
		[StringLength(60)]
		public string Email { get; set; }

		public string Bio { get; set; }

		[Required]
		public DateTime RegistrationDate { get; set; }

		[StringLength(7, MinimumLength = 1)]
		public string UsernameColor { get; set; }

		[Required]
		public bool ChatDisabled { get; set; }

		[Required]
		public string Achievements { get; set; }

		public DateTime LastLogin { get; set; }

		[Required]
		[StringLength(10, MinimumLength = 1)]
		public string Elevation { get; set; }

		[StringLength(30)]
		public string CustomAvatar { get; set; }

		public List<string> Friends { get; set; }
	}
}
