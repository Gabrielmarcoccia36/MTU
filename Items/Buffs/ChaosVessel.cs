using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MTU.Items.Buffs
{
    class ChaosVessel : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Chaos Vessel");
            Description.SetDefault("Chaos magic runs through your body\nIncreased magical damage, summon damage and mana regeneration");
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.magicDamage *= 1.4f;
            player.minionDamage *= 1.4f;
            player.manaRegen *= 2;
        }
    }
}
