using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using MTU.Players;

namespace MTU.Items.Buffs
{
    class SoulStoneBuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Soul Stone");
            Description.SetDefault("The souls you've collected empower you");
        }

        public override void Update(Player player, ref int buffIndex)
        {
            var mplayer = player.GetModPlayer<PlayerOne>();
            player.meleeDamage *= mplayer.soulsUpgrade;
            player.rangedDamage *= mplayer.soulsUpgrade;
            player.thrownDamage *= mplayer.soulsUpgrade;
            player.magicDamage *= mplayer.soulsUpgrade;
            player.minionDamage *= mplayer.soulsUpgrade;
        }
    }
}
