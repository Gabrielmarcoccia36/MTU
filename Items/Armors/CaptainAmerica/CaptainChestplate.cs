using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using MTU.Items.Materials;

namespace MTU.Items.Armors.CaptainAmerica
{
    [AutoloadEquip(EquipType.Body)]
    class CaptainChestplate : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Captain America's Chestplate");
            Tooltip.SetDefault("6% increased damage");
        }

        public override void SetDefaults()
        {
            item.width = 34;
            item.height = 20;
            item.maxStack = 1;
            item.value = Item.sellPrice(silver: 20);
            item.rare = ItemRarityID.LightPurple;
            item.defense = 22;
        }

        public override void UpdateEquip(Player player)
        {
            player.allDamage *= 1.06f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<VibraniumBar>(), 26);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}