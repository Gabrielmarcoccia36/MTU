using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using MTU.Players;
using Microsoft.Xna.Framework;

namespace MTU.Items.Weapons
{
    class HawkeyesBow : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Hawkeye's Bow");
            Tooltip.SetDefault("When Hawkeye's Quiver is equipped, this bow will randomly turn wooden arrows into stronger ones!");
        }
        public override void SetDefaults()
        {
            item.width = 24;
            item.height = 50;
            item.rare = ItemRarityID.LightPurple;
            item.value = Item.sellPrice(gold: 2);

            item.useTime = 30;
            item.useAnimation = 30;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.autoReuse = true;
            item.UseSound = SoundID.Item5;

            item.ranged = true;
            item.damage = 28;
            item.crit = 15;
            item.knockBack = 5f;
            item.noMelee = true;

            item.shootSpeed = 14f;
            item.useAmmo = AmmoID.Arrow;
            item.shoot = AmmoID.Arrow;
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            if (ModContent.GetInstance<PlayerOne>().GetHasHawkQuiver() && type == ProjectileID.WoodenArrowFriendly)
            {
                int var = Main.rand.Next(0, 4);

                if (var == 0)
                {
                    type = ProjectileID.FireArrow;
                }
                else if (var == 1)
                {
                    type = ProjectileID.UnholyArrow;
                }
                else if (var == 2)
                {
                    type = ProjectileID.JestersArrow;
                }
                else if (var == 3)
                {
                    type = ProjectileID.HellfireArrow;
                }

                return true;
            }
            else
            {
                item.shoot = AmmoID.Arrow;
                return true;
            }
        }

        public override bool ConsumeAmmo(Player player)
        {
            if (ModContent.GetInstance<PlayerOne>().GetHasHawkQuiver())
            {
                return Main.rand.NextFloat() >= 0.15f;
            }
            else
            {
                return base.ConsumeAmmo(player);
            }
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.MeteoriteBar, 10);
            recipe.AddIngredient(ItemID.HellstoneBar, 10);
            recipe.AddTile(ItemID.Hellforge);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
