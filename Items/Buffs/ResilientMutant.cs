using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using MTU.Players;

namespace MTU.Items.Buffs
{
    class ResilientMutant : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Resilient Mutant");
            Description.SetDefault("You posses resilient mutant genes\nIncreased defense\nKilling a boss for the first time will upgrade this buff");
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.statDefense += (int)player.GetModPlayer<PlayerOne>().mutDefense;
        }
    }
}
