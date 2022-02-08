using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MTU.Items.Buffs
{
    class ResilientMutant : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Resilient Mutant");
            Description.SetDefault("You posses resilient mutant genes\nSlight increase in defense");
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.statDefense += 5;
        }
    }
}
