using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MTU.Items.Buffs
{
    class BattleRuneBuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Battle Rune");
            Description.SetDefault("Being in proximity to this rune increases your combat effectiveness");
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.magicDamage *= 1.1f;
            player.minionDamage *= 1.1f;
            player.meleeDamage *= 1.1f;
            player.rangedDamage *= 1.1f;
            player.thrownDamage *= 1.1f;
        }
    }
}
