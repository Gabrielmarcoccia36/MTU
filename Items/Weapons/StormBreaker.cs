using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MTU.Items.Weapons
{
    class StormBreaker : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("StormBreaker");
            Tooltip.SetDefault("");
        }

        public override void SetDefaults()
        {
            item.damage = 120;
            item.width = 40;
            item.height = 40;
            item.maxStack = 1;
            item.value = Item.sellPrice(platinum: 10);
            item.rare = ItemRarityID.Cyan;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.useTime = 20;
            item.useAnimation = 20;
            item.useTurn = true;
            item.knockBack = 5;
            item.autoReuse = true;
            item.melee = true;
        }

    }
}