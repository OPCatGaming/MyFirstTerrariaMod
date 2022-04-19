using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;

namespace Mymod.Helpers
{
	public class SquareHelper
	{
		public static void Helper(Player player, int heightInTiles, int widthInTiles, int tileid, bool mute, bool forced)
		{
			//This stuff is for creating the bounds of the rectangle / square you are making and adjusting it depending on
			//if it has an odd height or width
			int UpperB = 0;
			int LowB = 0;
			int RightB = 0;
			int LeftB = 0;
			Vector2 URightC = new Vector2();
			Vector2 LRightC = new Vector2();
			Vector2 ULeftC = new Vector2();
			Vector2 LLeftC = new Vector2();

			if (heightInTiles%2 == 0 && widthInTiles%2 == 0)
            {
				//Bounds (Integers)
				UpperB = (heightInTiles * 16) / -2;
				LowB = (heightInTiles * 16) / 2;
			}
			if (widthInTiles%2 == 0)
            {
				//Bounds (Integers)
				RightB = (widthInTiles * 16) / 2;
				LeftB = (widthInTiles * 16) / -2;
			}
			if (heightInTiles % 2 != 0)
			{
				//Bounds (Integers)
				UpperB = ((heightInTiles + 1) * 16) / -2;
				LowB = ((heightInTiles + 1) * 16) / 2;
				Main.NewText("This height of square is not acceptable yet!");
			}
			if (widthInTiles % 2 != 0)
			{
				//Bounds (Integers)
				RightB = ((widthInTiles + 1) * 16) / 2;
				LeftB = ((widthInTiles + 1) * 16) / -2;
				Main.NewText("This width of square is not acceptable yet!");
			}
			URightC = new Vector2(player.position.X + (RightB - 16), player.position.Y + (UpperB + 16));
			LRightC = new Vector2(player.position.X + (RightB - 16), player.position.Y + LowB);
			ULeftC = new Vector2(player.position.X + LeftB, player.position.Y + (UpperB + 16));
			LLeftC = new Vector2(player.position.X + LeftB, player.position.Y + LowB);

			//These For loops are for creating the square
			//For the top blocks in the square
			for (float UpperBL = ULeftC.X; UpperBL < URightC.X; UpperBL += 16)
			{
				Vector2 tileplace = new Vector2(UpperBL, URightC.Y);
				WorldGen.PlaceTile(tileplace.ToTileCoordinates().X, tileplace.ToTileCoordinates().Y, tileid, mute, forced, 1, 1);
			}

			//For the bottom blocks in the square
			for (float LowerBL = ULeftC.X; LowerBL < URightC.X; LowerBL += 16)
			{
				Vector2 tileplace = new Vector2(LowerBL, LRightC.Y);
				WorldGen.PlaceTile(tileplace.ToTileCoordinates().X, tileplace.ToTileCoordinates().Y, tileid, mute, forced, 1, 1);
			}

			//For the right blocks in the square
			for (float RightBL = LRightC.Y; RightBL < URightC.Y; RightBL += 16)
			{
				Vector2 tileplace = new Vector2(URightC.X, RightBL);
				WorldGen.PlaceTile(tileplace.ToTileCoordinates().X, tileplace.ToTileCoordinates().Y, tileid, mute, forced, 1, 1);
			}

			//For the left blocks in the square
			for (float LeftBL = LLeftC.Y; LeftBL < ULeftC.Y; LeftBL += 16)
			{
				Vector2 tileplace = new Vector2(ULeftC.X, LeftBL);
				WorldGen.PlaceTile(tileplace.ToTileCoordinates().X, tileplace.ToTileCoordinates().Y, tileid, mute, forced, 1, 1);
			}
		}
	}
}

