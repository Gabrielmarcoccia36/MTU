﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MTU.Items.Projectiles
{
    class VibraniumShieldProjectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 5;
            ProjectileID.Sets.TrailingMode[projectile.type] = 0;
        }

        public override void SetDefaults()
        {
            projectile.Size = new Vector2(40);
            projectile.aiStyle = 3;

            projectile.friendly = true;
            projectile.melee = true;

            projectile.penetrate = -1;

            projectile.ignoreWater = true;
            projectile.tileCollide = false;

            aiType = ProjectileID.LightDisc;
        }
    }
}
