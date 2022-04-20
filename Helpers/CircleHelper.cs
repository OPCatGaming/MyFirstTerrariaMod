using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;

namespace Mymod.Helpers
{
	public class CircleHelper
	{
		public static void Maker(Vector2 pos, int diameter, int degrees)
        {
			if (degrees > 0)
            {
				int i = pos.ToTileCoordinates().X;
				int j = pos.ToTileCoordinates().Y;
				float r = ((float)diameter) / 2.0f;
				for (float t = 0; t < degrees; t++)
				{
					float x = (float)(r * Math.Cos(t) + i);
					float y = (float)(r * Math.Sin(t) + j);
					Vector2 tileplace = new Vector2(x * 16, y * 16);
					WorldGen.PlaceTile(tileplace.ToTileCoordinates().X, tileplace.ToTileCoordinates().Y, TileID.Copper, false, true, 1, 1);
				}
			}
		}
		public static void DrawCirclePoints(int points, double radius, Point center)
		{
			double slice = 2 * Math.PI / points;
			for (int i = 0; i < points; i++)
			{
				double angle = slice * i;
				int newX = (int)(center.X + radius * Math.Cos(angle));
				int newY = (int)(center.Y + radius * Math.Sin(angle));
				Point p = new Point(newX, newY);
				Vector2 tileplace = new Vector2(newX * 16, newY * 16);
				Main.NewText($"{p} point location    {tileplace.ToTileCoordinates()} tile location");
				WorldGen.PlaceTile(tileplace.ToTileCoordinates().X, tileplace.ToTileCoordinates().Y, TileID.Copper, false, true, 1, 1);
			}
		}
	}
}

