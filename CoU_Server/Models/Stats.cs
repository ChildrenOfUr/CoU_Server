using CoU_Server.Models.Accounts;
using System.ComponentModel.DataAnnotations;

namespace CoU_Server.Models {
	public class Stats {
		[Required]
		[Key]
		public int ID { get; set; }

		[Key]
		public User User { get; set; }

		[Required]
		public long StepsTaken { get; set; }

		[Required]
		public int Jumps { get; set; }

		[Required]
		public int ButterfliesMassaged { get; set; }

		[Required]
		public int ChickensSqueezed { get; set; }

		[Required]
		public int PiggiesNibbled { get; set; }

		[Required]
		public int AwesomePotUses { get; set; }

		[Required]
		public int CocktailShakerUses { get; set; }

		[Required]
		public int BlenderUses { get; set; }

		[Required]
		public int FamousPugilistGrillUses { get; set; }

		[Required]
		public int FryingPanUses { get; set; }

		[Required]
		public int KnifeBoardUses { get; set; }

		[Required]
		public int SaucePanUses { get; set; }

		[Required]
		public int ShrineDonations { get; set; }

		[Required]
		public int EmblemsCollected { get; set; }

		[Required]
		public int BarnaclesScraped { get; set; }

		[Required]
		public int DirtDug { get; set; }

		[Required]
		public int IceScraped { get; set; }

		[Required]
		public int JellisacHarvested { get; set; }

		[Required]
		public int PaperHarvested { get; set; }

		[Required]
		public int PeatHarvested { get; set; }

		[Required]
		public int RocksMined { get; set; }

		[Required]
		public int BeanTreesPetted { get; set; }

		[Required]
		public int BeanTreesWatered { get; set; }

		[Required]
		public int BeansHarvested { get; set; }

		[Required]
		public int BeansSeasoned { get; set; }

		[Required]
		public int BubbleTreesPetted { get; set; }

		[Required]
		public int BubbleTreesWatered { get; set; }

		[Required]
		public int BubblesHarvested { get; set; }

		[Required]
		public int BubblesTransformed { get; set; }

		[Required]
		public int EggPlantsPetted { get; set; }

		[Required]
		public int EggPlantsWatered { get; set; }

		[Required]
		public int EggsHarveted { get; set; }

		[Required]
		public int EggsSeasoned { get; set; }

		[Required]
		public int FruitTreesPetted { get; set; }

		[Required]
		public int FruitTreesWatered { get; set; }

		[Required]
		public int CherriesHarvested { get; set; }

		[Required]
		public int FruitConverted { get; set; }

		[Required]
		public int GasPlantsPetted { get; set; }

		[Required]
		public int GasPlantsWatered { get; set; }

		[Required]
		public int GasHarvested { get; set; }

		[Required]
		public int GasConverted { get; set; }

		[Required]
		public int SpicePlantsPetted { get; set; }

		[Required]
		public int SpicePlantsWatered { get; set; }

		[Required]
		public int SpiceHarvested { get; set; }

		[Required]
		public int SpiceMilled { get; set; }

		[Required]
		public int WoodTreesPetted { get; set; }

		[Required]
		public int WoodTreesWatered { get; set; }

		[Required]
		public int PlanksHarvested { get; set; }

		[Required]
		public int ButterfliesMilked { get; set; }

		[Required]
		public int CubimalBoxesOpened { get; set; }

		[Required]
		public int CubimalsSetFree { get; set; }

		[Required]
		public int EmblemsCaressed { get; set; }

		[Required]
		public int EmblemsConsidered { get; set; }

		[Required]
		public int EmblemsContemplated { get; set; }

		[Required]
		public int FavorEarned { get; set; }

		[Required]
		public int GrapesSquished { get; set; }

		[Required]
		public int HeliKittiesPetted { get; set; }

		[Required]
		public int IconsCollected { get; set; }

		[Required]
		public int IconsTithed { get; set; }

		[Required]
		public int IconsRevered { get; set; }

		[Required]
		public int IconsRuminated { get; set; }

		[Required]
		public int ItemsDropped { get; set; }

		[Required]
		public int ItemsPickedUp { get; set; }

		[Required]
		public int ItemsFromVendors { get; set; }

		[Required]
		public int PiggiesPetted { get; set; }

		[Required]
		public int QuoinsCollected { get; set; }

		[Required]
		public int SalmonPocketed { get; set; }

		[Required]
		public int TinkertoolUses { get; set; }

		[Required]
		public int SmelterUses { get; set; }

		[Required]
		public int CropsHarvested { get; set; }

		[Required]
		public int CropsPlanted { get; set; }

		[Required]
		public int CropsWatered { get; set; }

		[Required]
		public int CropsHoed { get; set; }

		[Required]
		public int PiggiesFed { get; set; }

		[Required]
		public int TestTubeUses { get; set; }

		[Required]
		public int BeakerUses { get; set; }

		[Required]
		public int RainboSnoconesBlended { get; set; }
	}
}