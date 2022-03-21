using Terraria;
using Terraria.ID;

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
    }
}
