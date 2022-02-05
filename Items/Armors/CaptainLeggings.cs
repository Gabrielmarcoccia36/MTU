using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MTU.Items.Armors
{
    [AutoloadEquip(EquipType.Legs)]
    class CaptainLeggings : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Captain America Leggings");
            Tooltip.SetDefault("Feel the History");
        }

        public override void SetDefaults()
        {
            item.width = 22;
            item.height = 18;
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