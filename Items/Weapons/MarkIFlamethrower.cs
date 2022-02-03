using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using MTU.Items.Projectiles;

namespace MTU.Items.Weapons
{
    class MarkIFlamethrower : ModItem
    {
		public override string Texture => "Terraria/Item_" + ItemID.Flamethrower;

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Mark I Flamethrower");
			Tooltip.SetDefault("Having the Mark I set armor will make this weapon not consume mana on use");
		}

		public override void SetDefaults()
		{
			item.damage = 20;
			item.ranged = true;
			item.width = 50;
			item.height = 18;
			item.scale = .5f;
			// A useTime of 4 with a useAnimation of 20 means this weapon will shoot out 5 jets of fire in one shot.
			// Vanilla Flamethrower uses values of 6 and 30 respectively, which is also 5 jets in one shot, but over 30 frames instead of 20.
			item.useTime = 4;
			item.useAnimation = 20;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.noMelee = true; // So the item's animation doesn't do damage
			item.knockBack = 0.2f; // A high knockback. Vanilla Flamethrower uses 0.3f for a weak knockback.
			item.color = Color.Gray; // Makes the item color green, since we are reusing vanilla sprites for simplicity.
			item.rare = ItemRarityID.Green; // Sets the item's rarity.
			item.UseSound = SoundID.Item34;
			item.autoReuse = true;
			item.shoot = ModContent.ProjectileType<MarkIFlamethrowerProjectile>();
			item.shootSpeed = 6f; // How fast the flames will travel. Vanilla Flamethrower uses 7f and consequentially has less reach. item.shootSpeed and projectile.timeLeft together control the range.
			item.mana = 10;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.PlatinumBar, 16);
			recipe.AddIngredient(ItemID.Torch, 3);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 54f; //This gets the direction of the flame projectile, makes its length to 1 by normalizing it. It then multiplies it by 54 (the item width) to get the position of the tip of the flamethrower.
			if (Collision.CanHit(position, 6, 6, position + muzzleOffset, 6, 6))
			{
				position += muzzleOffset;
			}
			// This is to prevent shooting through blocks and to make the fire shoot from the muzzle.
			return true;
		}
		public override Vector2? HoldoutOffset()
		// HoldoutOffset has to return a Vector2 because it needs two values (an X and Y value) to move your flamethrower sprite. Think of it as moving a point on a cartesian plane.
		{
			return new Vector2(0, -2); // If your own flamethrower is being held wrong, edit these values. You can test out holdout offsets using Modder's Toolkit.
		}
	}
}
