using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MTU.Items.Weapons
{
    public class Mjolnir : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Mjolnir");
        }

        public override void SetDefaults()
        {
            item.width = 38;
            item.height = 38;
            item.melee = true;
            item.value = Item.buyPrice(gold: 1);
            item.rare = ItemRarityID.Green;
            item.UseSound = SoundID.Item1;
            item.crit = 6;
            item.knockBack = 6;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.damage = 250;

            item.useTime = 20;
            item.useAnimation = 20;
            item.autoReuse = true;
            item.useStyle = ItemUseStyleID.SwingThrow;
        }

        public override bool AltFunctionUse(Player player) => true;

        public override bool CanUseItem(Player player)
        {
            if (player.altFunctionUse == 2) //Charge
            {
                item.useTime = item.useAnimation = 20;
                item.autoReuse = false;
                item.shoot = ModContent.ProjectileType<MjolnirProjectile>();
                item.noUseGraphic = item.noMelee = true;
            }
            else //Basic melee
            {
                item.useTime = item.useAnimation = 20;
                item.autoReuse = true;
                item.shoot = ProjectileID.None;
                item.noUseGraphic = item.noMelee = false;
            }
            return player.altFunctionUse != 2 || (player.ownedProjectileCounts[ModContent.ProjectileType<MjolnirProjectile>()] <= 0);
        }
    }

    public class MjolnirProjectile : ModProjectile
    {
        public override string Texture => "MTU/Items/Weapons/Mjolnir";

        private int _charge = 0;
        private bool _hold = true;

        public override void SetDefaults()
        {
            projectile.width = 36;
            projectile.height = 36;
            projectile.friendly = true;
            projectile.penetrate = -1;
            projectile.tileCollide = false;
            projectile.ignoreWater = true;
            projectile.ranged = true;
            projectile.aiStyle = -1;

            drawHeldProjInFrontOfHeldItemAndArms = true;
        }

        public override bool CanDamage() => false;

        public override void AI()
        {
            Player p = Main.player[projectile.owner];
            p.heldProj = projectile.whoAmI;

            if (p.whoAmI != Main.myPlayer)
                return;

            p.bodyFrame.Y = 56 * 2;
            projectile.position = p.Center + new Vector2(0, p.gfxOffY);

            if (!Main.mouseRight)
                _hold = false;

            if (_hold)
            {
                _charge++; //Increase charge timer...
                projectile.timeLeft++; //...and dont die
            }
            else
            {
                if (_charge >= 50)
                {
                    Vector2 dir = projectile.DirectionTo(Main.MouseWorld);

                    int proj = Projectile.NewProjectile(projectile.position + dir * 60, Vector2.Zero, ModContent.ProjectileType<MjolnirLightning>(), projectile.damage, 2f, projectile.owner);
                    Projectile pr = Main.projectile[proj];
                    pr.rotation = dir.ToRotation();

                    if (pr.modProjectile is MjolnirLightning mjolnir)
                    {
                        mjolnir.constDir = dir;
                        mjolnir.direction = dir;
                    }
                }

                projectile.Kill();
            }
        }

        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            Texture2D tex = Main.projectileTexture[projectile.type];
            Vector2 origin = new Vector2(0, tex.Height);
            Vector2 drawPos = projectile.position - Main.screenPosition;
            float rotation = -MathHelper.PiOver4;

            spriteBatch.Draw(tex, drawPos, null, Color.White, rotation, origin, Vector2.One, SpriteEffects.None, 0f);

            if (_charge > 50f)
            {
                Vector2 off = new Vector2(-tex.Width, tex.Height).RotatedBy(rotation) / 2f;
                float sine = 1 + ((float)Math.Sin((_charge - 50f) * 0.02f) * 0.2f);

                spriteBatch.Draw(tex, drawPos - off, null, Color.White * 0.5f, rotation, tex.Size() / 2f, Vector2.One * sine, SpriteEffects.None, 0f);
            }
            return false;
        }
    }

    public class MjolnirLightning : ModProjectile
    {
        public Vector2 constDir = default;
        public Vector2 direction = default;
        public int repeats = 0;

        public override void SetDefaults()
        {
            projectile.width = 40;
            projectile.height = 40;
            projectile.friendly = true;
            projectile.penetrate = -1;
            projectile.tileCollide = false;
            projectile.ignoreWater = true;
            projectile.ranged = true;
            projectile.aiStyle = -1;
            projectile.timeLeft = 15;
        }

        public override void AI()
        {
            projectile.rotation = direction.ToRotation();

            if (projectile.timeLeft == 14 && !Collision.SolidCollision(projectile.position, projectile.width, projectile.height))
            {
                int proj = Projectile.NewProjectile(projectile.Center + (direction * 60), Vector2.Zero, ModContent.ProjectileType<MjolnirLightning>(), projectile.damage, 2f, projectile.owner);
                Projectile pr = Main.projectile[proj];

                Vector2 newDir = direction.RotatedByRandom(MathHelper.PiOver4);
                if (Math.Abs(newDir.ToRotation() - constDir.ToRotation()) > MathHelper.PiOver4 / 2.0)
                    newDir = constDir;

                pr.rotation = newDir.ToRotation();

                if (pr.modProjectile is MjolnirLightning mjolnir)
                {
                    mjolnir.constDir = constDir;
                    mjolnir.direction = newDir;
                }
            }

            if (Main.rand.NextFloat() <= 0.125f)
                Dust.NewDustPerfect(projectile.Center, DustID.Electric, direction * Main.rand.NextFloat(5f, 10.5f));
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit) => target.AddBuff(BuffID.Electrified, 30);
    }
}
