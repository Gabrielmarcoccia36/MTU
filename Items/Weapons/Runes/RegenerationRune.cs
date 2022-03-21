using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using MTU.Items.Buffs;

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
    }
}
