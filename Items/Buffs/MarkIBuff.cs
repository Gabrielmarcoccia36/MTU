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
            Description.SetDefault("This suit allows brief flight, grants extra armor but, due to its massive weight, it slows you down!");
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.rocketBoots = 1;
            player.moveSpeed -= 0.45f;
            player.statDefense += 4;
            player.rocketTimeMax = 3;
        }
    }
}