using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MTU.Items.InfinityStones
{
    class TimeStone : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Time Stone");
            Tooltip.SetDefault("Time is in your hands");
        }

        public override void SetDefaults()
        {
            item.width = 14;
            item.height = 14;
            item.maxStack = 1;
            item.value = Item.sellPrice(platinum: 10);
            item.rare = ItemRarityID.Purple;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.useTime = 40;
            item.useAnimation = 20;
            item.material = true;
        }

        public override bool UseItem(Player player)
        {
            player.AddBuff(2, 36000);
            player.AddBuff(3, 36000);
            player.AddBuff(6, 36000);
            player.AddBuff(8, 36000);
            player.AddBuff(104, 36000);

            return true;
        }
    }
}