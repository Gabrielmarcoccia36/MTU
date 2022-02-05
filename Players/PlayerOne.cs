using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using MTU.Items.Materials;
using MTU.Items.Buffs;
using Microsoft.Xna.Framework;

namespace MTU.Players
{
    public class PlayerOne : ModPlayer
    {
        public bool hasHawkQuiver, hasAether, hasCaptain, hasChaosBuff;

        public override void Initialize()
        {
            hasChaosBuff = false;
        }

        public override void Load(TagCompound tag)
        {
            hasChaosBuff = tag.GetBool("hasChaosBuff");
        }

        public override TagCompound Save()
        {
            return new TagCompound
            {
                {"hasChaosBuff", hasChaosBuff }
            };

        }

        public override void PreUpdate()
        {
            if (hasChaosBuff)
            {
                player.AddBuff(ModContent.BuffType<ChaosVessel>(), 2);
            }
    }

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
        public override void ResetEffects()
        {
            hasCaptain = false;
        }
    }
}
