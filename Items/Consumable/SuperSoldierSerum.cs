using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using MTU.Players;
using MTU.Items.Materials;

namespace MTU.Items.Consumable
{
    class SuperSoldierSerum : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Super Soldier Serum");
            Tooltip.SetDefault("Used to be a very painful procedure");
        }

        public override void SetDefaults()
        {
            item.width = 24;
            item.height = 40;
            item.maxStack = 1;
            item.consumable = true;
            item.value = Item.sellPrice(gold: 25);
            item.rare = ItemRarityID.Red;
            item.useStyle = ItemUseStyleID.EatingUsing;
            item.useAnimation = 15;
            item.useTime = 15;
            item.useTurn = true;
            item.UseSound = SoundID.Item3;
            item.consumable = true;
        }

        public override bool UseItem(Player player)
        {
            if (!player.GetModPlayer<PlayerOne>().hasChaosBuff && !player.GetModPlayer<PlayerOne>().hasSoldierBuff && !player.GetModPlayer<PlayerOne>().hasAgentBuff)
            {
                Main.NewText(player.name + " is now a Super Soldier!");
                player.GetModPlayer<PlayerOne>().hasSoldierBuff = true;
                return true;
            }
            else
            {
                return false;
            }
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<ChaosParticle>(), 60);
            recipe.AddIngredient(ItemID.Bottle, 1);
            recipe.AddTile(TileID.Bottles);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
