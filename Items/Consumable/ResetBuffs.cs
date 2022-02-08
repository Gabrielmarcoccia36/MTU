using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using MTU.Players;
using MTU.Items.Materials;

namespace MTU.Items.Consumable
{
    class ResetBuffs : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Reset Buffs");
            Tooltip.SetDefault("Debug Item");
        }

        public override void SetDefaults()
        {
            item.width = 24;
            item.height = 40;
            item.maxStack = 1;
            item.rare = ItemRarityID.Red;
            item.useStyle = ItemUseStyleID.EatingUsing;
            item.useAnimation = 15;
            item.useTime = 15;
            item.useTurn = true;
            item.UseSound = SoundID.Item3;
        }

        public override bool UseItem(Player player)
        {
            player.GetModPlayer<PlayerOne>().hasChaosBuff = false;
            player.GetModPlayer<PlayerOne>().hasSoldierBuff = false;
            player.GetModPlayer<PlayerOne>().hasAgentBuff = false;
            player.GetModPlayer<PlayerOne>().hasFrenziedBuff = false;
            player.GetModPlayer<PlayerOne>().hasResilientBuff = false;
            player.GetModPlayer<PlayerOne>().hasSwiftBuff = false;
            player.GetModPlayer<PlayerOne>().tryMutant = false;

            return true;
        }
    }
}
