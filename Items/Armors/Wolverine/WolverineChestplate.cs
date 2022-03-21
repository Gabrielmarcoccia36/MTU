using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using MTU.Items.Materials;

namespace MTU.Items.Armors.Wolverine
{
    [AutoloadEquip(EquipType.Body)]
    class WolverineChestplate : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Wolverine's Chestplate");
            Tooltip.SetDefault("15% increased melee damage");
        }

        public override void SetDefaults()
        {
            item.width = 34;
            item.height = 20;
            item.maxStack = 1;
            item.value = Item.sellPrice(gold: 40, silver: 80);
            item.rare = ItemRarityID.Yellow;
            item.defense = 18;
        }

        public override void UpdateEquip(Player player)
        {
            player.meleeDamage *= 1.15f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<AdamantiumBar>(), 26);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}