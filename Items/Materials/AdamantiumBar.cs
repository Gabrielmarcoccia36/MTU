using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace MTU.Items.Materials
{
    class AdamantiumBar : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Adamantium Bar");
            Tooltip.SetDefault("Legendary metal alloy");
        }

        public override void SetDefaults()
        {
            item.width = 8;
            item.height = 8;
            item.maxStack = 999;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.useTime = 10;
            item.useAnimation = 10;
            item.material = true;
            item.value = Item.sellPrice(gold: 1, silver: 40);
        }
        public override void AddRecipes()
        {
            ModRecipe recipe1 = new ModRecipe(mod);
            recipe1.AddIngredient(ItemID.HellstoneBar, 2);
            recipe1.AddIngredient(ItemID.TitaniumBar, 2);
            recipe1.AddIngredient(ModContent.ItemType<VibraniumBar>(), 2);
            recipe1.AddTile(TileID.AdamantiteForge);
            recipe1.SetResult(this);
            recipe1.AddRecipe();

            ModRecipe recipe2 = new ModRecipe(mod);
            recipe2.AddIngredient(ItemID.HellstoneBar, 2);
            recipe2.AddIngredient(ItemID.AdamantiteBar, 2);
            recipe2.AddIngredient(ModContent.ItemType<VibraniumBar>(), 2);
            recipe2.AddTile(TileID.AdamantiteForge);
            recipe2.SetResult(this);
            recipe2.AddRecipe();
        }
    }
}
