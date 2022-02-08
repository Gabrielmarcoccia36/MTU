using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MTU.Items.Buffs
{
    class FrenziedMutant : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Frenzied Mutant");
            Description.SetDefault("You posses frenzied mutant genes\nSlight damage increase");
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.allDamage *= 1.05f;
        }
    }
}
