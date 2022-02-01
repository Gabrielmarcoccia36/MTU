using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MTU.Items.Buffs
{
    class MarkIBuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Mark I Buff");
            Description.SetDefault("The Mark I allows for a brief flight");
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.rocketBoots = 1;
        }
    }
}
