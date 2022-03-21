using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MTU.Items.Buffs
{
    class RegenerationRuneBuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Regeneration Rune");
            Description.SetDefault("Being in proximity to this rune increases your regenerative capability");
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.lifeRegen *= 2;
            player.manaRegen *= 2;
        }
    }
}
