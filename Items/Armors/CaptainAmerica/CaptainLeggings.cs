using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using MTU.Items.Materials;

namespace MTU.Items.Armors.CaptainAmerica
{
    [AutoloadEquip(EquipType.Legs)]
    class CaptainLeggings : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Captain America's Leggings");
            Tooltip.SetDefault("5% increased crit chance and movement speed");
        }

        public override void SetDefaults()
        {
            item.width = 22;
            item.height = 18;
            item.value = Item.sellPrice(silver: 10);
            item.rare = ItemRarityID.LightPurple;
            item.defense = 16;
        }

        public override void UpdateEquip(Player player)
        {
            player.meleeCrit = 5;
            player.moveSpeed *= 1.05f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<VibraniumBar>(), 16);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}