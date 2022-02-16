using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using MTU.Players;

namespace MTU.Items.Buffs
{
    class SwiftMutant : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Swift Mutant");
            Description.SetDefault("You posses swift mutant genes\nIncreased movement speed\nKilling a boss for the first time will upgrade this buff");
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.moveSpeed *= player.GetModPlayer<PlayerOne>().mutSpeed;
        }
    }
}
