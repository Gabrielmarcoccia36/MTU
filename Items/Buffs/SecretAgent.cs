using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MTU.Items.Buffs
{
    class SecretAgent : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Secret Agent");
            Description.SetDefault("You are a proficient ranged killed\nIncreased ranged damage and movement speed");
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.rangedDamage *= 1.4f;
            player.moveSpeed *= 1.3f;
        }
    }
}
