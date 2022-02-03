using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using MTU.Items.Projectiles;
using MTU.Items.Materials;
using Microsoft.Xna.Framework;

namespace MTU.Items.Weapons
{
    class VibraniumShield : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Vibranium Shield");
            Tooltip.SetDefault("Right-click to reduced damage taken");
        }
        public override void SetDefaults()
        {
            item.width = 40;
            item.height = 40;
            item.rare = ItemRarityID.Pink;

            item.useTime = 30;
            item.useAnimation = 8;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.autoReuse = false;

            item.melee = true;
            item.damage = 65;
            item.knockBack = 2f;
            item.noMelee = true;

            item.shootSpeed = 18f;
            item.shoot = ModContent.ProjectileType<VibraniumShieldProjectile>();
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.GetInstance<VibraniumBar>(), 25);
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
                item.damage = 65;
                item.knockBack = 2f;
                item.shoot = ModContent.ProjectileType<VibraniumShieldProjectile>();
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
