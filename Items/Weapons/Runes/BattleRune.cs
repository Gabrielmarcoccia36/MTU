using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using MTU.Items.Buffs;
using Microsoft.Xna.Framework;

namespace MTU.Items.Weapons.Runes
{
    /// <summary>
    /// Example rune for reference.
    /// </summary>
    public class BattleRune : BaseRune
    {
        internal override int Range => 600;

        internal override void NPCEffect(NPC npc)
        {
            //npc.AddBuff(BuffID.OnFire, 2);
        }

        internal override void PlayerEffect(Player player)
        {
            player.AddBuff(ModContent.BuffType<BattleRuneBuff>(), 2);
        }

        internal override void SafeAI()
        {
            int dust = Dust.NewDust(projectile.position + new Vector2(15,18), 1, 1, DustID.Firework_Yellow, Main.rand.Next(-5, 5), Main.rand.Next(-5, 5), 175, default, .75f);
            Main.dust[dust].noGravity = true;
        }
    }
}
