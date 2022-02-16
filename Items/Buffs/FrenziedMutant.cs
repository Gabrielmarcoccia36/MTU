using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using MTU.Players;

namespace MTU.Items.Buffs
{
    class FrenziedMutant : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Frenzied Mutant");
            Description.SetDefault("You posses frenzied mutant genes\nIncreased damage\nKilling a boss for the first time will upgrade this buff");
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.allDamage *= player.GetModPlayer<PlayerOne>().mutDamage;
        }
    }
}
