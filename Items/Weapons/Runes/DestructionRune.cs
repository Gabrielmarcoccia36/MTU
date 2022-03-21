using Terraria;
using Terraria.ID;
using Microsoft.Xna.Framework;

namespace MTU.Items.Weapons.Runes
{
    /// <summary>
    /// Example rune for reference.
    /// </summary>
    public class DestructionRune : BaseRune
    {
        internal override int Range => 600;

        internal override void NPCEffect(NPC npc)
        {
            npc.AddBuff(BuffID.OnFire, 2);
            npc.AddBuff(BuffID.Ichor, 2);
        }

        internal override void PlayerEffect(Player player)
        {
        }
        internal override void SafeAI()
        {
            int dust = Dust.NewDust(projectile.position + new Vector2(15, 15), 1, 1, DustID.Water_Crimson, Main.rand.Next(-25, 25), Main.rand.Next(-25, 25), 0, default, 1f);
            Main.dust[dust].noGravity = true;
            int dust2 = Dust.NewDust(projectile.position + new Vector2(15, 15), 1, 1, DustID.Water_Crimson, Main.rand.Next(-25, 25), Main.rand.Next(-25, 25), 0, default, 1f);
            Main.dust[dust2].noGravity = true;
        }
    }
}
