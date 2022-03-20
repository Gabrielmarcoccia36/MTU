using Terraria;
using Terraria.ID;

namespace MTU.Items.Weapons.Runes
{
    /// <summary>
    /// Example rune for reference.
    /// This rune applies OnFire to nearby NPCs, and gives Regeneration to nearby Players.
    /// It has a slightly higher range than default.
    /// </summary>
    public class ExampleRune : BaseRune
    {
        internal override int Range => 600;

        internal override void NPCEffect(NPC npc)
        {
            npc.AddBuff(BuffID.OnFire, 2);
        }

        internal override void PlayerEffect(Player player)
        {
            player.AddBuff(BuffID.Regeneration, 2);
        }
    }
}
