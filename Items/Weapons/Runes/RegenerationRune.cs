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
    public class RegenerationRune : BaseRune
    {
        internal override int Range => 600;

        internal override void NPCEffect(NPC npc)
        {
        }

        internal override void PlayerEffect(Player player)
        {
            player.AddBuff(ModContent.BuffType<RegenerationRuneBuff>(), 2);
        }
        internal override void SafeAI()
        {
            int dust = Dust.NewDust(projectile.position + new Vector2(10, 15), 1, 1, DustID.Shadowflame, Main.rand.Next(-10, 10), Main.rand.Next(-10, 10), 200, default, 1f);
            Main.dust[dust].noGravity = true;
        }
    }
}
