using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using MTU.Items.Projectiles;
using MTU.Items.Materials;
using Microsoft.Xna.Framework;

namespace MTU.Items.Weapons
{
    class AdamantiumShield : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Adamanitum Shield");
            Tooltip.SetDefault("Right-click to reduced damage taken");
        }
        public override void SetDefaults()
        {
            item.width = 40;
            item.height = 40;
            item.rare = ItemRarityID.Purple;

            item.useTime = 30;
            item.useAnimation = 8;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.autoReuse = false;

            item.melee = true;
            item.damage = 125;
            item.knockBack = 2f;
            item.noMelee = true;

            item.shootSpeed = 18f;
            item.shoot = ModContent.ProjectileType<AdamantiumShieldProjectile>();
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<AdamantiumBar>(), 30);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
        public override bool AltFunctionUse(Player player)
        {
            return true;
        }

        public override bool CanUseItem(Player player)
        {
            if (player.altFunctionUse == 2)
            {
                item.useStyle = ItemUseStyleID.HoldingOut;
                item.useTime = 60;
                item.autoReuse = false;
                item.useAnimation = 20;
                player.AddBuff(BuffID.Endurance, 120);
            }
            else
            {
                item.useStyle = ItemUseStyleID.SwingThrow;
                item.useTime = 20;
                item.useAnimation = 8;
                item.damage = 125;
                item.knockBack = 2f;
                item.shoot = ModContent.ProjectileType<AdamantiumShieldProjectile>();
            }
            return base.CanUseItem(player);
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            if (player.altFunctionUse == 2)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
