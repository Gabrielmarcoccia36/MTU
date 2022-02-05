using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MTU.Items.Armors
{
    [AutoloadEquip(EquipType.Body)]
    class CaptainChestplate : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Captain America Chestplate");
            Tooltip.SetDefault("Feel the History");
        }

        public override void SetDefaults()
        {
            item.width = 34;
            item.height = 20;
            item.maxStack = 1;
            item.value = Item.sellPrice(silver: 20);
            item.rare = ItemRarityID.Green;
            item.defense = 4;
        }



        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.IronBar, 30);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}