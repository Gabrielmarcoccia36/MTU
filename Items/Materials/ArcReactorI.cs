using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MTU.Items.Materials
{
    class ArcReactorI : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Arc Reactor I");
            Tooltip.SetDefault("Proof that Tony Stark has a heart...");
        }
        public override void SetDefaults()
        {
            item.width = 28;
            item.height = 28;
            item.maxStack = 1;
            item.value = Item.sellPrice(copper: 80);
            item.rare = ItemRarityID.Green;
            item.material = true;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe1 = new ModRecipe(mod);
            recipe1.AddIngredient(ModContent.ItemType<Uranium>(), 120);
            recipe1.AddIngredient(ItemID.IronBar, 5);
            recipe1.AddIngredient(ItemID.Chain, 25);
            recipe1.AddTile(TileID.Anvils);
            recipe1.SetResult(this);
            recipe1.AddRecipe();

            ModRecipe recipe2 = new ModRecipe(mod);
            recipe2.AddIngredient(ModContent.ItemType<Uranium>(), 120);
            recipe2.AddIngredient(ItemID.LeadBar, 5);
            recipe2.AddIngredient(ItemID.Chain, 25);
            recipe2.AddTile(TileID.Anvils);
            recipe2.SetResult(this);
            recipe2.AddRecipe();
        }
    }
}
