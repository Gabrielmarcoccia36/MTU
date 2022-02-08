using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using MTU.Items.Consumable;
using MTU.Items.Materials;
using MTU.Items.Weapons;
using MTU.Players;

namespace MTU.NPCs
{
    class MTUGlobalNPC : GlobalNPC
    {
        public override void NPCLoot(NPC npc)
        {
            ModContent.GetInstance<PlayerOne>().enemiesKilled++;
            Main.NewText(ModContent.GetInstance<PlayerOne>().enemiesKilled);
            
            if (npc.type == NPCID.TheDestroyer || npc.type == NPCID.Retinazer || npc.type == NPCID.Spazmatism)
            {
                // Either of the mechanicals = vibranium
                if (Main.rand.Next(2) == 0)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<WakandasBlessing>());
                }

                // destroyer = Training Routine
                if (npc.type == NPCID.TheDestroyer)
                {
                    if (Main.rand.Next(2) == 0)
                    {
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<TrainingRoutine>());
                    }
                }
                // twins = Super Soldier Serum
                if (npc.type == NPCID.Retinazer || npc.type == NPCID.Spazmatism)
                {
                    if (Main.rand.Next(2) == 0)
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
                if (Main.rand.Next(5) == 0)
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
        }
    }
}