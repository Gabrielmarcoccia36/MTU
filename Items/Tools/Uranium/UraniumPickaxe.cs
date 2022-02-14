using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using MTU.Items.Materials;
using Microsoft.Xna.Framework;

namespace MTU.Items.Tools.Uranium
{
    class UraniumPickaxe : ModItem
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Uranium Pickaxe");
		}

		public override void SetDefaults()
		{
			item.damage = 4;
			item.melee = true;
			item.width = 40;
			item.height = 40;
			item.useTime = 10;
			item.useAnimation = 20;
			item.pick = 38;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.knockBack = 6;
			item.value = Item.sellPrice(silver: 1, copper: 25);
			item.rare = ItemRarityID.Green;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<Materials.Uranium>(), 36);
			recipe.AddIngredient(ItemID.Wood, 5);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}

		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			if (Main.rand.NextBool(20))
			{
                _ = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustID.Clentaminator_Green);
            }
		}
	}
}
