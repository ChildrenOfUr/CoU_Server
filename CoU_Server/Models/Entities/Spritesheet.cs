namespace CoU_Server.Models.Entities {
	public class Spritesheet {
		public string StateName;
		public string URL;

		public int SheetWidth, SheetHeight;
		public int FrameWidth, FrameHeight;
		public int NumFrames;
		public int NumRows, NumCols;

		public bool Loops = false;

		public int LoopDelay;

		public Spritesheet(string stateName, string url, int sheetWidth, int sheetHeight, int frameWidth, int frameHeight, int numFrames, bool loops, int loopDelay = 0) {
			StateName = stateName;
			URL = url;
			SheetWidth = sheetWidth;
			SheetHeight = sheetHeight;
			FrameWidth = frameWidth;
			FrameHeight = frameHeight;
			NumFrames = numFrames;
			Loops = loops;
			LoopDelay = loopDelay;
			NumRows = sheetHeight / frameHeight;
			NumCols = sheetWidth / frameWidth;
		}

		public Spritesheet(string stateName, string url, int width, int height) {
			StateName = stateName;
			URL = url;
			SheetWidth = width;
			SheetHeight = height;
			FrameWidth = width;
			FrameHeight = height;
			NumFrames = 1;
			Loops = true;
			LoopDelay = 0;
			NumRows = 1;
			NumCols = 1;
		}

		public override string ToString() {
			return StateName;
		}
	}
}
