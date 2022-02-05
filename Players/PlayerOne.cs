using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using MTU.Items.Materials;
using Microsoft.Xna.Framework;

namespace MTU.Players
{
    public class PlayerOne : ModPlayer
    {
        public bool hasHawkQuiver, hasAether;

        public bool GetHasHawkQuiver()
        {
			return hasHawkQuiver;
        }
        public override void OnHitByNPC(NPC npc, int damage, bool crit)
        {
            if (hasAether)
            {
                Main.NewText(hasAether);
                int proj = Projectile.NewProjectile(npc.position, new Vector2(0,0), ProjectileID.Bomb, 7, 0, 1);
                Main.projectile[proj].timeLeft = 3;
            }
        }
    }
}
