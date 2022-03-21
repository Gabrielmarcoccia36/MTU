using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using MTU.Items.Materials;

namespace MTU.Items.Armors.Wolverine
{
    [AutoloadEquip(EquipType.Legs)]
    class WolverineLeggings : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Wolverine's Leggings");
            Tooltip.SetDefault("8% melee increased crit chance\n12% increased movement speed");
        }

        public override void SetDefaults()
        {
            item.width = 22;
            item.height = 18;
            item.value = Item.sellPrice(gold: 25, silver: 60);
            item.rare = ItemRarityID.Yellow;
            item.defense = 10;
        }

        public override void UpdateEquip(Player player)
        {
            player.meleeCrit += 8;
            player.moveSpeed *= 1.12f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<AdamantiumBar>(), 16);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}