using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MTU.Items.Buffs
{
    class WarMachineBuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("War Machine Buff");
            Description.SetDefault("This suit grants flight, shows you resources and enemies location, and has night vision!");
        }
        public override void Update(Player player, ref int buffIndex)
        {
            player.rocketBoots = 1;
            player.rocketTimeMax = 20;
            player.moveSpeed *= 2.8f;
            player.AddBuff(BuffID.Spelunker, 2);
            player.AddBuff(BuffID.Hunter, 2);
            player.AddBuff(BuffID.NightOwl, 2);
        }
    }
}