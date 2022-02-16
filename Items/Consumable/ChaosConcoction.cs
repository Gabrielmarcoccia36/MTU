using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using MTU.Players;
using MTU.Items.Materials;

namespace MTU.Items.Consumable
{
    class ChaosConcoction : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Chaos Concotion");
            Tooltip.SetDefault("Consume at your own risk!");
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
            item.useAnimation = 20;
            item.useTime = 20;
            item.useTurn = true;
            item.UseSound = SoundID.Item3;
            item.consumable = true;
        }

        public override bool UseItem(Player player)
        {
            if (!player.GetModPlayer<PlayerOne>().hasChaosBuff && !player.GetModPlayer<PlayerOne>().hasSoldierBuff && !player.GetModPlayer<PlayerOne>().hasAgentBuff)
            {
                Main.NewText(player.name + " is now a Chaos Vessel!");
                player.GetModPlayer<PlayerOne>().hasChaosBuff = true;
            }
            else if (player.GetModPlayer<PlayerOne>().hasChaosBuff)
            {
                Main.NewText(player.name + " is already a Chaos Vessel!");
                player.Hurt(Terraria.DataStructures.PlayerDeathReason.ByCustomReason("Stop experimenting with your body!"), 50, 0);
            }
            else if (player.GetModPlayer<PlayerOne>().hasSoldierBuff)
            {
                Main.NewText(player.name + " is already a Super Soldier!");
                player.Hurt(Terraria.DataStructures.PlayerDeathReason.ByCustomReason("Stop experimenting with your body!"), 50, 0);
            }
            else if (player.GetModPlayer<PlayerOne>().hasAgentBuff)
            {
                Main.NewText(player.name + " is already a Secret Agent!");
                player.Hurt(Terraria.DataStructures.PlayerDeathReason.ByCustomReason("Stop experimenting with your body!"), 50, 0);
            }
            return true;
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
