using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using MTU.Items.Buffs;

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
    }
}
