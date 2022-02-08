using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MTU.Items.Buffs
{
    class SwiftMutant : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Swift Mutant");
            Description.SetDefault("You posses swift mutant genes\nSlight increase in movement speed");
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.moveSpeed *= 1.1f;
        }
    }
}
