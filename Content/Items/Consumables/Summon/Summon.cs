using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Mymod.Helpers;

namespace Mymod.Content.Items.Consumables.Summon
{
	public class Summon : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Minion Boss Summon Item");
			Tooltip.SetDefault("Summons Minion Boss");

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 3;
			ItemID.Sets.SortingPriorityBossSpawns[Type] = 12; // This helps sort inventory know that this is a boss summoning Item.

			// If this would be for a vanilla boss that has no summon item, you would have to include this line here:
			// NPCID.Sets.MPAllowedEnemies[NPCID.Plantera] = true;

			// Otherwise the UseItem code to spawn it will not work in multiplayer
		}

		public override void SetDefaults()
		{
			Item.width = 20;
			Item.height = 20;
			Item.maxStack = 20;
			Item.value = 100;
			Item.rare = ItemRarityID.Blue;
			Item.useAnimation = 30;
			Item.useTime = 30;
			Item.useStyle = ItemUseStyleID.HoldUp;
			Item.consumable = true;
		}

		public override bool CanUseItem(Player player)
		{
			// If you decide to use the below UseItem code, you have to include !NPC.AnyNPCs(id), as this is also the check the server does when receiving MessageID.SpawnBoss.
			// If you want more constraints for the summon item, combine them as boolean expressions:
			//    return !Main.dayTime && !NPC.AnyNPCs(ModContent.NPCType<MinionBossBody>()); would mean "not daytime and no MinionBossBody currently alive"
			return !NPC.AnyNPCs(NPCID.EyeofCthulhu);
		}

		public override bool? UseItem(Player player)
		{
			// This next code is my code for spawning in the Arena (Aka. it might not work)
			int height = 10;
			int width = 10;
			SquareHelper.Helper(player, height, width, TileID.Stone, true, true);
			//NPC.SpawnBoss((int)player.position.X, (int)(player.position.Y + (height * 16) / 2), NPCID.EyeofCthulhu, 1);

			return true;
		}
	}
}

