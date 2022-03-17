using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using MTU.Items.Materials;

namespace MTU.Items.Ammo
{
    class UraniumBullet : ModItem
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Uranium Bullet");
		}

		public override void SetDefaults()
		{
			item.damage = 8;
			item.ranged = true;
			item.width = 8;
			item.height = 8;
			item.maxStack = 999;
			item.consumable = true;
			item.knockBack = 1.1f;
			item.value = Item.sellPrice(copper: 2);
			item.rare = ItemRarityID.Green;
			item.shoot = ModContent.ProjectileType<Projectiles.UraniumBulletProjectile>();
			item.shootSpeed = 12f;
			item.ammo = AmmoID.Bullet;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.MusketBall, 50);
			recipe.AddIngredient(ModContent.ItemType<Uranium>(), 5);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this, 50);
			recipe.AddRecipe();
		}
	}
}
