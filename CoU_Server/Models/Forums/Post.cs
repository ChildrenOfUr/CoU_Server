﻿using CoU_Server.Models.Accounts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CoU_Server.Models.Forums {
	public class Post {
		[Required]
		[Key]
		public int ID { get; set; }

		[StringLength(60)]
		public string Title { get; set; }

		[StringLength(30)]
		public string Category { get; set; }

		public string Content { get; set; }

		[Required]
		public DateTime Created { get; set; }

		[Required]
		public DateTime Edited { get; set; }

		[Required]
		public User User { get; set; }

		public List<User> Watchers { get; set; }
	}
}
