using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using MTU.Items.Consumable;
using MTU.Items.Materials;
using MTU.Items.Weapons;
using MTU.Items.InfinityStones;
using MTU.Players;

namespace MTU.NPCs
{
    class MTUGlobalNPC : GlobalNPC
    {
        public override void NPCLoot(NPC npc)
        {
            var player = Main.LocalPlayer.GetModPlayer<PlayerOne>();
            
            #region Loot
            if (npc.type == NPCID.TheDestroyer || npc.type == NPCID.Retinazer || npc.type == NPCID.Spazmatism)
            {
                // Either of the mechanicals = vibranium
                if (Main.rand.Next(3) == 0)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<WakandasBlessing>());
                }

                // destroyer = Training Routine
                if (npc.type == NPCID.TheDestroyer)
                {
                    if (Main.rand.Next(4) == 0)
                    {
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<TrainingRoutine>());
                    }
                }
                // twins = Super Soldier Serum
                if (npc.type == NPCID.Retinazer || npc.type == NPCID.Spazmatism)
                {
                    if (Main.rand.Next(4) == 0)
                    {
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<SuperSoldierSerum>());
                    }
                }
            }

            // Skeletron prime sets active chaos particle spawn
            if (npc.type == NPCID.SkeletronPrime && !ModContent.GetInstance<MTUWorld>().GetKilledSkeletronPrime())
            {
                ModContent.GetInstance<MTUWorld>().SetKilledSkeletronPrime(true);
            }

            // NPCs in hell = chaos particles
            if ((npc.position.Y / 16f >= Main.maxTilesY - 200 || npc.position.Y >= (Main.maxTilesY - 200) * 16) && ModContent.GetInstance<MTUWorld>().GetKilledSkeletronPrime())
            {
                if (Main.rand.Next(4) == 0)
                {
                    Item.NewItem(npc.getRect(), ModContent.ItemType<ChaosParticle>(), Main.rand.Next(3));
                }
            }

            // Golem = Mjolnir
            if (npc.type == NPCID.Golem)
            {
                if (Main.rand.Next(3) == 0)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<Mjolnir>());
                }
            }

            // Fishrom = Stormbreaker
            if (npc.type == NPCID.DukeFishron)
            {
                if (Main.rand.Next(2) == 0)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<StormBreaker>());
                }
            }

            // Cultist = Eye of Agamotto
            if (npc.type == NPCID.CultistBoss)
            {
                if (Main.rand.Next(2) == 0)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<EyeOfAgamotto>());
                }
            }

            // Surface enemies = cheese
            if (npc.position.Y / 16f <= Main.worldSurface && npc.position.Y / 16 >= Main.worldSurface * 0.35f)
            {
                if (Main.rand.Next(10) == 0)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<Cheese>());
                }
            }

            // MoonLord
            if (npc.type == NPCID.MoonLordCore)
            {
                if (Main.rand.Next(5) == 0)
                {
                    if (Main.rand.Next(1) == 0)
                    {
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<TheOrb>());
                    }
                    else
                    {
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<SoulStone>());
                    }
                }
            }
            #endregion

            #region IFStones
            
            #endregion

            #region Mutant Buff's Progression
            if (player.tryMutant)
            {
                // 0 King slime
                if (player.bossesKilled[0] == 0 && npc.type == NPCID.KingSlime)
                {
                    if (player.hasFrenziedBuff)
                    {
                        player.mutDamage += 0.01f;
                    }
                    else if (player.hasResilientBuff)
                    {
                        player.mutDefense += 1;
                    }
                    else
                    {
                        player.mutSpeed += 0.01f;
                    }
                    player.bossesKilled[0] = 1;
                }
                // 1 Eye of Cthulhu
                if (player.bossesKilled[1] == 0 && npc.type == NPCID.EyeofCthulhu)
                {
                    if (player.hasFrenziedBuff)
                    {
                        player.mutDamage += 0.01f;
                    }
                    else if (player.hasResilientBuff)
                    {
                        player.mutDefense += 1;
                    }
                    else
                    {
                        player.mutSpeed += 0.01f;
                    }
                    player.bossesKilled[1] = 1;
                }
                // 2 Eater of Worlds or Brain of Cthulhu
                if (player.bossesKilled[2] == 0 && (npc.type == NPCID.EaterofWorldsHead || npc.type == NPCID.BrainofCthulhu))
                {
                    if (player.hasFrenziedBuff)
                    {
                        player.mutDamage += 0.01f;
                    }
                    else if (player.hasResilientBuff)
                    {
                        player.mutDefense += 1;
                    }
                    else
                    {
                        player.mutSpeed += 0.01f;
                    }
                    player.bossesKilled[2] = 1;
                }
                // 3 Queen Bee
                if (player.bossesKilled[3] == 0 && npc.type == NPCID.EyeofCthulhu)
                {
                    if (player.hasFrenziedBuff)
                    {
                        player.mutDamage += 0.01f;
                    }
                    else if (player.hasResilientBuff)
                    {
                        player.mutDefense += 1;
                    }
                    else
                    {
                        player.mutSpeed += 0.01f;
                    }
                    player.bossesKilled[3] = 1;
                }
                // 4 Skeletron
                if (player.bossesKilled[4] == 0 && npc.type == NPCID.SkeletronHead)
                {
                    if (player.hasFrenziedBuff)
                    {
                        player.mutDamage += 0.01f;
                    }
                    else if (player.hasResilientBuff)
                    {
                        player.mutDefense += 1;
                    }
                    else
                    {
                        player.mutSpeed += 0.01f;
                    }
                    player.bossesKilled[4] = 1;
                }
                // 5 Wall of Flesh
                if (player.bossesKilled[5] == 0 && npc.type == NPCID.SkeletronHead)
                {
                    if (player.hasFrenziedBuff)
                    {
                        player.mutDamage += 0.01f;
                    }
                    else if (player.hasResilientBuff)
                    {
                        player.mutDefense += 1;
                    }
                    else
                    {
                        player.mutSpeed += 0.01f;
                    }
                    player.bossesKilled[5] = 1;
                }
                // 6 The twins
                if (player.bossesKilled[6] == 0 && (npc.type == NPCID.Retinazer || npc.type == NPCID.Spazmatism))
                {
                    if (player.hasFrenziedBuff)
                    {
                        player.mutDamage += 0.01f;
                    }
                    else if (player.hasResilientBuff)
                    {
                        player.mutDefense += 1;
                    }
                    else
                    {
                        player.mutSpeed += 0.01f;
                    }
                    player.bossesKilled[6] = 1;
                }
                // 7 Destroyer
                if (player.bossesKilled[7] == 0 && npc.type == NPCID.TheDestroyer)
                {
                    if (player.hasFrenziedBuff)
                    {
                        player.mutDamage += 0.01f;
                    }
                    else if (player.hasResilientBuff)
                    {
                        player.mutDefense += 1;
                    }
                    else
                    {
                        player.mutSpeed += 0.01f;
                    }
                    player.bossesKilled[7] = 1;
                }
                // 8 Skeletron Prime
                if (player.bossesKilled[8] == 0 && npc.type == NPCID.SkeletronPrime)
                {
                    if (player.hasFrenziedBuff)
                    {
                        player.mutDamage += 0.01f;
                    }
                    else if (player.hasResilientBuff)
                    {
                        player.mutDefense += 1;
                    }
                    else
                    {
                        player.mutSpeed += 0.01f;
                    }
                    player.bossesKilled[8] = 1;
                }
                // 9 Plantera
                if (player.bossesKilled[9] == 0 && npc.type == NPCID.Plantera)
                {
                    if (player.hasFrenziedBuff)
                    {
                        player.mutDamage += 0.01f;
                    }
                    else if (player.hasResilientBuff)
                    {
                        player.mutDefense += 1;
                    }
                    else
                    {
                        player.mutSpeed += 0.01f;
                    }
                    player.bossesKilled[9] = 1;
                }
                // 10 Golem
                if (player.bossesKilled[10] == 0 && npc.type == NPCID.Golem)
                {
                    if (player.hasFrenziedBuff)
                    {
                        player.mutDamage += 0.01f;
                    }
                    else if (player.hasResilientBuff)
                    {
                        player.mutDefense += 1;
                    }
                    else
                    {
                        player.mutSpeed += 0.01f;
                    }
                    player.bossesKilled[10] = 1;
                }
                // 11 Duke fishron
                if (player.bossesKilled[11] == 0 && npc.type == NPCID.DukeFishron)
                {
                    if (player.hasFrenziedBuff)
                    {
                        player.mutDamage += 0.01f;
                    }
                    else if (player.hasResilientBuff)
                    {
                        player.mutDefense += 1;
                    }
                    else
                    {
                        player.mutSpeed += 0.01f;
                    }
                    player.bossesKilled[11] = 1;
                }
                // 12 Cultist
                if (player.bossesKilled[12] == 0 && npc.type == NPCID.CultistBoss)
                {
                    if (player.hasFrenziedBuff)
                    {
                        player.mutDamage += 0.01f;
                    }
                    else if (player.hasResilientBuff)
                    {
                        player.mutDefense += 1;
                    }
                    else
                    {
                        player.mutSpeed += 0.01f;
                    }
                    player.bossesKilled[12] = 1;
                }
                // 13 Moonlord
                if (player.bossesKilled[13] == 0 && npc.type == NPCID.MoonLordCore)
                {
                    if (player.hasFrenziedBuff)
                    {
                        player.mutDamage += 0.01f;
                    }
                    else if (player.hasResilientBuff)
                    {
                        player.mutDefense += 1;
                    }
                    else
                    {
                        player.mutSpeed += 0.01f;
                    }
                    player.bossesKilled[13] = 1;
                }
            }
            #endregion
        }

        #region SoulStone
        public override void HitEffect(NPC npc, int hitDirection, double damage)
        {
            var player = Main.LocalPlayer.GetModPlayer<PlayerOne>();

            // Soul stone effect. Every 150 kills, 1% damage increase
            if (Main.LocalPlayer.HasItem(ModContent.ItemType<SoulStone>()))
            {
                if (npc.life <= 0)
                {
                    if (player.collectedSouls == 149)
                    {
                        player.collectedSouls = 0;
                        player.soulsUpgrade += 0.01f;
                    }
                    else
                    {
                        player.collectedSouls++;
                    }
                    int dust = Dust.NewDust(npc.position, 1, 1, DustID.LavaBubbles, 0, 0, 0, default, 3f);
                    Main.dust[dust].noGravity = true;
                }
            }
            
        }
        #endregion
    }
}