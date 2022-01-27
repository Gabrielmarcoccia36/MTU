using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MTU.Items.InfinityStones
{
    class PowerStone : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Power Stone");
            Tooltip.SetDefault("Unlimited Power has a price");
        }

        public override void SetDefaults()
        {
            item.width = 14;
            item.height = 14;
            item.maxStack = 1;
            item.value = Item.sellPrice(platinum: 10);
            item.rare = 11;
            item.useStyle = 1;
            item.useTime = 40;
            item.useAnimation = 20;
            item.material = true;
        }

        public override bool UseItem(Player player)
        {
            player.AddBuff(5, 36000);
            player.AddBuff(7, 36000);
            player.AddBuff(14, 36000);
            player.AddBuff(16, 36000);
            player.AddBuff(108, 36000);
            player.AddBuff(110, 36000);
            player.AddBuff(114, 36000);
            player.AddBuff(115, 36000);
            player.AddBuff(117, 36000);

            player.Hurt(Terraria.DataStructures.PlayerDeathReason.ByCustomReason("Your body was too weak!"), 50, 0);

            return true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod, "TheOrb");
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
