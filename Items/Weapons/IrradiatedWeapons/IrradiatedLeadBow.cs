﻿using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using MTU.Items.Projectiles;
using MTU.Items.Materials;

namespace MTU.Items.Weapons.IrradiatedWeapons
{
    class IrradiatedLeadBow : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Irradiated Lead Bow");
            Tooltip.SetDefault("Turns wooden arrows into irradiated arrows");
        }
        public override void SetDefaults()
        {
            item.width = 24;
            item.height = 50;
            item.rare = ItemRarityID.White;
            item.value = Item.sellPrice(silver: 4, copper: 40);

            item.useTime = 40;
            item.useAnimation = 40;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.autoReuse = false;
            item.UseSound = SoundID.Item5;

            item.ranged = true;
            item.damage = 9;
            item.crit = 1;
            item.knockBack = 0f;
            item.noMelee = true;

            item.shootSpeed = 10f;
            item.useAmmo = AmmoID.Arrow;
            item.shoot = AmmoID.Arrow;
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            if (type == ProjectileID.WoodenArrowFriendly)
            {
                type = ModContent.ProjectileType<IrradiatedArrows>();
            }
            return true;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.LeadBow, 1);
            recipe.AddIngredient(ModContent.ItemType<Uranium>(), 20);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}