using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoU_Server.Models.Entities.StreetEntities {
	public class StreetEntity {
		[Required]
		[Key]
		public string ID { get; set; }

		public string Type { get; set; }

		public string TSID { get; set; }

		public double X { get; set; }
		
		public double Y { get; set; }

		public double Z { get; set; }
		
		public double Rotation { get; set; }

		public bool HFlip { get; set; }

		public string MetadataJSON { get; set; }

		[NotMapped]
		public Dictionary<string, string> Metadata {
			get {
				// TODO: decode MetadataJSON
				throw new NotImplementedException();
			}

			set {
				// TODO: encode MetadataJSON
				throw new NotImplementedException();
			}
		}

		public override string ToString() {
			return $"<StreetEntity {ID} ({Type}) on {TSID} at ({X}, {Y}, {Z}), flip: {HFlip}, rotation: {Rotation} with metadata {MetadataJSON}>";
		}
	}
}
