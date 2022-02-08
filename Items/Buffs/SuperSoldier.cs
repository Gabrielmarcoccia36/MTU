using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MTU.Items.Buffs
{
    class SuperSoldier : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Super Soldier");
            Description.SetDefault("Your physical condition is at its peak\nIncreased melee damage and life regeneration");
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.meleeDamage *= 1.4f;
            player.lifeRegen *= 2;
        }
    }
}
