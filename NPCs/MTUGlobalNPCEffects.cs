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
    class MTUGlobalNPCEffects : GlobalNPC
    {
        public bool irradiated;

        public override bool InstancePerEntity => true;

        public override void ResetEffects(NPC npc)
        {
            irradiated = false;
        }
        public override void UpdateLifeRegen(NPC npc, ref int damage)
        {
            if (irradiated)
            {
                if (npc.lifeRegen > 0)
                {
                    npc.lifeRegen = 0;
                }
                npc.lifeRegen -= 10;
                if (damage < 2)
                {
                    damage = 2;
                }
            }
        }
        public override void DrawEffects(NPC npc, ref Color drawColor)
        {
            if (irradiated)
            {
                if (Main.rand.Next(4) < 3)
                {
                    int dust = Dust.NewDust(npc.position - new Vector2(2f, 2f), npc.width + 4, npc.height + 4, DustID.Chlorophyte, npc.velocity.X * 0.4f, npc.velocity.Y * 0.4f, 100, default, 1.2f);
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].velocity *= 1.1f;
                    Main.dust[dust].velocity.Y -= 0.5f;
                    if (Main.rand.NextBool(4))
                    {
                        Main.dust[dust].noGravity = false;
                        Main.dust[dust].scale *= 1;
                    }
                }
                Lighting.AddLight(npc.position, 0.0f, 0.95f, 0.0f);
            }
        }
    }
}
