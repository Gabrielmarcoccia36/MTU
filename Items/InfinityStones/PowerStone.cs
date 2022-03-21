using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using MTU.Items.Materials;

namespace MTU.Items.InfinityStones
{
    class PowerStone : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Power Stone");
            Tooltip.SetDefault("Unlimited Power has a price");
            Item.staff[item.type] = true;
        }

        public override void SetDefaults()
        {
            item.width = 14;
            item.height = 14;
            item.maxStack = 1;
            item.value = Item.sellPrice(platinum: 10);
            item.rare = ItemRarityID.Purple;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.useTime = 10;
            item.useAnimation = 10;
            item.material = true;
            item.magic = true;
            item.damage = 2500;
            item.shootSpeed = 5;
            item.knockBack = 8;
            item.autoReuse = true;
            item.noMelee = true;
        }

        public override bool AltFunctionUse(Player player)
        {
            return true;
        }

        public override bool CanUseItem(Player player)
        {
            if (player.altFunctionUse == 2)
            {
                item.useStyle = ItemUseStyleID.HoldingUp;
                item.useTime = 40;
                item.useAnimation = 20;
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
                return false;
            }
            else
            {
                item.useTime = 15;
                item.useAnimation = 15;
                item.useStyle = ItemUseStyleID.HoldingOut;
                item.shoot = ModContent.ProjectileType<PowerStoneBeam>();
                player.Hurt(Terraria.DataStructures.PlayerDeathReason.ByCustomReason("You couldn't handle the strain!"), 80, 0);
            }
            return base.CanUseItem(player);
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<TheOrb>(), 1);
            recipe.AddTile(TileID.AdamantiteForge);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }

    class PowerStoneBeam : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 10;
            projectile.height = 10;
            // NO! projectile.aiStyle = 48;
            projectile.friendly = true;
            projectile.magic = true;
            projectile.extraUpdates = 120;
            projectile.timeLeft = 400; // lowered from 300
            projectile.penetrate = 20;
            projectile.tileCollide = false;
        }

        // Note, this Texture is actually just a blank texture, FYI.
        public override string Texture => "Terraria/Projectile_" + ProjectileID.ShadowBeamFriendly;

        /*public override bool OnTileCollide(Vector2 oldVelocity)
        {
            if (projectile.velocity.X != oldVelocity.X)
            {
                projectile.position.X = projectile.position.X + projectile.velocity.X;
                projectile.velocity.X = -oldVelocity.X;
            }
            if (projectile.velocity.Y != oldVelocity.Y)
            {
                projectile.position.Y = projectile.position.Y + projectile.velocity.Y;
                projectile.velocity.Y = -oldVelocity.Y;
            }
            return false; // return false because we are handling collision
        }*/

        public override void ModifyHitNPC(NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
        {
            //projectile.damage = (int)(projectile.damage * 0.8);
        }

        public override void AI()
        {
            projectile.localAI[0] += 1f;
            if (projectile.localAI[0] > 9f)
            {
                for (int i = 0; i < 4; i++)
                {
                    Vector2 projectilePosition = projectile.position;
                    projectilePosition -= projectile.velocity * ((float)i * 0.25f);
                    projectile.alpha = 255;
                    int dust = Dust.NewDust(projectilePosition, 1, 1, DustID.ShadowbeamStaff, 0f, 0f, 0, default, 1f);
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].position = projectilePosition;
                    Main.dust[dust].scale = (float)Main.rand.Next(70, 110) * 0.025f;
                    Main.dust[dust].velocity *= 0.2f;
                }
                for (int i = 0; i < 4; i++)
                {
                    Vector2 projectilePosition = projectile.position;
                    projectilePosition.Y -= 4;
                    projectilePosition -= projectile.velocity * ((float)i * 0.25f);
                    projectile.alpha = 255;
                    int dust = Dust.NewDust(projectilePosition, 1, 1, DustID.ShadowbeamStaff, 0f, 0f, 0, default, 1f);
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].position = projectilePosition;
                    Main.dust[dust].scale = (float)Main.rand.Next(70, 110) * 0.025f;
                    Main.dust[dust].velocity *= 0.2f;
                }
                for (int i = 0; i < 4; i++)
                {
                    Vector2 projectilePosition = projectile.position;
                    projectilePosition.Y -= 8;
                    projectilePosition -= projectile.velocity * ((float)i * 0.25f);
                    projectile.alpha = 255;
                    int dust = Dust.NewDust(projectilePosition, 1, 1, DustID.ShadowbeamStaff, 0f, 0f, 0, default, 1f);
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].position = projectilePosition;
                    Main.dust[dust].scale = (float)Main.rand.Next(70, 110) * 0.025f;
                    Main.dust[dust].velocity *= 0.2f;
                }
                for (int i = 0; i < 4; i++)
                {
                    Vector2 projectilePosition = projectile.position;

                    projectilePosition.Y -= 12;
                    projectilePosition -= projectile.velocity * ((float)i * 0.25f);
                    projectile.alpha = 255;
                    int dust = Dust.NewDust(projectilePosition, 1, 1, DustID.ShadowbeamStaff, 0f, 0f, 0, default, 1f);
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].position = projectilePosition;
                    Main.dust[dust].scale = (float)Main.rand.Next(70, 110) * 0.025f;
                    Main.dust[dust].velocity *= 0.2f;
                }
                for (int i = 0; i < 4; i++)
                {
                    Vector2 projectilePosition = projectile.position;
                    projectilePosition.Y -= 16;
                    projectilePosition -= projectile.velocity * ((float)i * 0.25f);
                    projectile.alpha = 255;
                    int dust = Dust.NewDust(projectilePosition, 1, 1, DustID.ShadowbeamStaff, 0f, 0f, 0, default, 1f);
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].position = projectilePosition;
                    Main.dust[dust].scale = (float)Main.rand.Next(70, 110) * 0.025f;
                    Main.dust[dust].velocity *= 0.2f;
                }
            }
        }
    }
}
