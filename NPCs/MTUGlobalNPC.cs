using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using MTU.Items.Consumable;
using MTU.Items.Materials;

namespace MTU.NPCs
{
    class MTUGlobalNPC : GlobalNPC
    {
        public override void NPCLoot(NPC npc)
        {
            if (npc.type == NPCID.TheDestroyer || npc.type == NPCID.Retinazer || npc.type == NPCID.Spazmatism)
            {
                if (Main.rand.Next(2) == 0)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<WakandasBlessing>());
                }
            }

            if(npc.position.Y >= Main.maxTilesY - 200)
            {
                if (Main.rand.Next(5) == 0)
                {
                    if (Main.rand.Next(3) == 0)
                    {
                        Item.NewItem(npc.getRect(), ModContent.ItemType<ChaosParticle>(), 2);
                    }
                    else if (Main.rand.Next(6) == 0)
                    {
                        Item.NewItem(npc.getRect(), ModContent.ItemType<ChaosParticle>(), 3);
                    }
                    else
                    {
                        Item.NewItem(npc.getRect(), ModContent.ItemType<ChaosParticle>(), 1);
                    }
                }
            }
        }
    }
}