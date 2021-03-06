using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MTU.Items.Projectiles
{
    class IrradiatedArrows : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 5;
            ProjectileID.Sets.TrailingMode[projectile.type] = 0;
        }

        public override void SetDefaults()
        {
            projectile.Size = new Vector2(14, 40);
            projectile.aiStyle = 1;

            projectile.friendly = true;
            projectile.ranged = true;

            projectile.penetrate = 1;

            projectile.ignoreWater = true;
            projectile.tileCollide = true;

            aiType = ProjectileID.FireArrow;
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            if (Main.rand.Next(3) == 0)
            {
                target.AddBuff(mod.BuffType("Irradiated"), 150);
            }
        }
    }
}
