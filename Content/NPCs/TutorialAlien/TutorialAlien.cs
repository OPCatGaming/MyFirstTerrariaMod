using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using Terraria.GameContent.ItemDropRules;

namespace Mymod.Content.NPCs.TutorialAlien
{
	public class TutorialAlien : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Alien");
			Main.npcFrameCount[NPC.type] = 8;
		}

		public override void SetDefaults()
		{
			
			NPC.width = 24;
			NPC.height = 44;
			NPC.damage = 70;
			NPC.defense = 30;
			NPC.lifeMax = 600;
			NPC.buffImmune[BuffID.Poisoned] = true;
			NPC.buffImmune[BuffID.WeaponImbueVenom] = true;
			NPC.HitSound = SoundID.NPCHit6;
			NPC.DeathSound = SoundID.NPCDeath8;
			NPC.value = 10000f;
			NPC.knockBackResist = .25f;
			NPC.aiStyle = 26;
			AIType = NPCID.Unicorn;
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			if (NPC.downedMechBossAny && Main.eclipse && spawnInfo.player.ZoneOverworldHeight)
			{
				return 0.07f;
			}
			return 0f;
		}
		

		public override void HitEffect(int hitDirection, double damage)
		{
			
			if (NPC.life <= 0)
			{
				Gore.NewGore(NPC.position, NPC.velocity, GoreID.Balloon_Red_1 , 1f);
				Gore.NewGore(NPC.position, NPC.velocity, GoreID.Balloon_Red_1 , 1f);
				Gore.NewGore(NPC.position, NPC.velocity, GoreID.Balloon_Red_1 , 1f);
				Gore.NewGore(NPC.position, NPC.velocity, GoreID.Balloon_Red_1 , 1f);
				Gore.NewGore(NPC.position, NPC.velocity, GoreID.Balloon_Red_1 , 1f);
				if (Main.rand.Next(4) == 1)
				{
					Item.NewItem((IEntitySource)NPC, NPC.position, ItemID.Acorn, 100, false, 0, true);
				}
				int[] lootTable = {
					ItemID.AaronsBreastplate,
					ItemID.AaronsHelmet,
					ItemID.AaronsLeggings,
					ItemID.Abeemination
				};
				int loot = Main.rand.Next(lootTable.Length);
				NPC.DropItemInstanced(NPC.position,NPC.position,lootTable[loot]);
			}
		}

		public override void FindFrame(int frameHeight)
		{
			NPC.frameCounter += 0.40f;
			NPC.frameCounter %= Main.npcFrameCount[NPC.type];
			int frame = (int)NPC.frameCounter;
			NPC.frame.Y = frame * frameHeight;
		}

		public override void AI()
		{
			NPC.spriteDirection = NPC.direction;
		}
		public override void OnHitPlayer(Player target, int damage, bool crit)
		{
			if (Main.rand.Next(4) == 1)
			{
				target.AddBuff(BuffID.Venom, 260);
			}
		}
	}
}

