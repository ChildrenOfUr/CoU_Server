using System.ComponentModel.DataAnnotations;


namespace CoU_Server.Models.Streets {
	public class StreetEntity {
		[Required]
		[Key]
		[StringLength(30)]
		public int ID { get; set; }

		[Required]
		[StringLength(60)]
		public string Type { get; set; }

		[StringLength(20)]
		public string TSID { get; set; }

		[Required]
		public int X { get; set; }

		[Required]
		public int Y { get; set; }

		[Required]
		public int Z { get; set; }

		public bool HFlip { get; set; }

		public int Rotation { get; set; }

		[Required]
		public string Metadata { get; set; }
	}
}
