using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MTU.Items.Materials
{
    class ArcReactorII : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Arc Reactor II");
            Tooltip.SetDefault("'Badassium'");
        }
        public override void SetDefaults()
        {
            item.width = 28;
            item.height = 28;
            item.maxStack = 1;
            item.value = Item.sellPrice(gold: 2);
            item.rare = ItemRarityID.Lime;
            item.material = true;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe1 = new ModRecipe(mod);
            recipe1.AddIngredient(ModContent.ItemType<Uranium>(), 60);
            recipe1.AddIngredient(ModContent.ItemType<ArcReactorI>(), 1);
            recipe1.AddIngredient(ItemID.ChlorophyteBar, 5);
            recipe1.AddTile(TileID.MythrilAnvil);
            recipe1.SetResult(this);
            recipe1.AddRecipe();
        }
    }
}
