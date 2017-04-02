using System;
using System.Collections.Generic;

namespace CoU_Server.Models.Items {
	public class Item {
		public static Dictionary<string, Item> Items { get; private set; }

		public string ID { get; protected set; }
		public string ItemType { get; protected set; }
		public string Name { get; protected set; }
		public string Description { get; protected set; }
		public string Category { get; protected set; }
		public string RecipeName { get; protected set; }

		public string IconUrl { get; protected set; }
		public string SpriteUrl { get; protected set; }
		public string BrokenUrl { get; protected set; }
		public string ToolAnimation { get; protected set; }
		public int IconNum { get; protected set; }
		
		public int Price { get; protected set; }
		public int StacksTo { get; protected set; }
		public int Durability { get; protected set; }
		public int SubSlots { get; protected set; }
		public bool IsContainer { get; protected set; }
		public List<string> SubSlotFilter { get; protected set; }
		
		public List<Action> Actions { get; protected set; }
		public Dictionary<string, int> ConsumeValues { get; protected set; }
		public Dictionary<string, string> Metadata { get; protected set; }

		public float X { get; set; }
		public float Y { get; set; }
		public bool OnGround { get; set; }

		public bool FilterAllows(Item testItem = null, string itemType = null) {
			// Allow an empty slot
			if (testItem == null && itemType == null) {
				return true;
			}

			if (itemType != null && string.IsNullOrEmpty(itemType) {
				// Bags except empty item types (this is an empty slot)
				return true;
			}

			if (testItem == null) {
				testItem = Items[itemType];
			}

			if (SubSlotFilter.Count == 0) {
				return !testItem.IsContainer;
			} else {
				return SubSlotFilter.Contains(testItem.ItemType);
			}
		}

		public override string ToString() {
			return $"An item of type {ItemType} with metadata {Metadata}";
		}
	}
}
