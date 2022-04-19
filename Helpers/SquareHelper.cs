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
			int UpperB = (heightInTiles * 16) / -2;
			int LowB = (heightInTiles * 16) / 2;
			int RightB = (widthInTiles * 16) / 2;
			int LeftB = (widthInTiles * 16) / -2;
			Vector2 URightC = new Vector2(RightB, UpperB);
			Vector2 LRightC = new Vector2(RightB, LowB);
			Vector2 ULeftC = new Vector2(LeftB, UpperB);
			Vector2 LLeftC = new Vector2(LeftB, LowB);

			//For the top blocks in the square
			for (int UpperBL = (int)player.position.X + LeftB; UpperBL < (int)player.position.X + RightB; UpperBL += 16)
			{
				Vector2 tileplace = new Vector2(player.position.X + UpperBL, player.position.Y + UpperB);
				WorldGen.PlaceTile(tileplace.ToTileCoordinates().X, tileplace.ToTileCoordinates().Y, tileid, mute, forced, 1, 1);
			}

			//For the bottom blocks in the square
			for (int LowerBL = (int)player.position.X + LeftB; LowerBL < (int)player.position.X + RightB; LowerBL += 16)
			{
				Vector2 tileplace = new Vector2(player.position.X + LowerBL, player.position.Y + LowB);
				WorldGen.PlaceTile(tileplace.ToTileCoordinates().X, tileplace.ToTileCoordinates().Y, tileid, mute, forced, 1, 1);
			}

			//For the right blocks in the square
			for (int RightBL = (int)player.position.X + LowB; RightBL < (int)player.position.X + UpperB; RightBL += 16)
			{
				Vector2 tileplace = new Vector2(player.position.X + RightB, player.position.X + RightBL);
				WorldGen.PlaceTile(tileplace.ToTileCoordinates().X, tileplace.ToTileCoordinates().Y, tileid, mute, forced, 1, 1);
			}

			//For the left blocks in the square
			for (int LeftBL = (int)player.position.X + LowB; LeftBL < (int)player.position.X + UpperB; LeftBL += 16)
			{
				Vector2 tileplace = new Vector2(player.position.X + LeftB, player.position.X + LeftBL);
				WorldGen.PlaceTile(tileplace.ToTileCoordinates().X, tileplace.ToTileCoordinates().Y, tileid, mute, forced, 1, 1);
			}
		}
	}
}

