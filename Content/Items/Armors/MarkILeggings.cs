using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MTU.Content.Items.Armors
{
    [AutoloadEquip(EquipType.Legs)]
    class MarkILeggings : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Mark I Leggings");
            Tooltip.SetDefault("Heavy, but efficient");
        }

        public override void SetDefaults()
        {
            item.width = 22;
            item.height = 22;
            item.value = Item.sellPrice(silver: 10);
            item.rare = ItemRarityID.Green;
            item.defense = 2;
        }


        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.IronBar, 25);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}