using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace MTU.Items.Materials
{
    class VibraniumBar : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Vibranium Bar");
            Tooltip.SetDefault("This is said to absorb most vibrations");
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
            item.rare = ItemRarityID.Pink;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.Materials.Vibranium>(), 4);
            recipe.AddTile(TileID.Hellforge);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
