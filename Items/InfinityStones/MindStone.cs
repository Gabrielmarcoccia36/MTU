using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using MTU.Items.Weapons;

namespace MTU.Items.InfinityStones
{
    class MindStone : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Mind Stone");
            Tooltip.SetDefault("Hear its call");
        }

        public override void SetDefaults()
        {
            item.width = 14;
            item.height = 14;
            item.maxStack = 1;
            item.value = Item.sellPrice(platinum: 10);
            item.rare = ItemRarityID.Purple;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.useTime = 40;
            item.useAnimation = 20;
            item.material = true;
        }
        public override bool UseItem(Player player)
        {
            player.AddBuff(10, 36000);

            return true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Scepter>(), 1);
            recipe.AddTile(TileID.AdamantiteForge);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
