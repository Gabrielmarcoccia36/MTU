using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;


namespace MTU.Items.Weapons
{
    class StormBreaker : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("StormBreaker");
            Tooltip.SetDefault("");
        }

        public override void SetDefaults()
        {
            item.damage = 190;
            item.width = 54;
            item.height = 54;
            item.maxStack = 1;
            item.value = Item.sellPrice(platinum: 10);
            item.rare = ItemRarityID.Cyan;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.useTime = 30;
            item.useAnimation = 30;
            item.useTurn = true;
            item.knockBack = 5;
            item.autoReuse = true;
            item.melee = true;
            item.shoot = ModContent.ProjectileType<StormBreakerSlash>();
            item.shootSpeed = 12;

        }

    }

    public class StormBreakerSlash : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 5;
            ProjectileID.Sets.TrailingMode[projectile.type] = 0;
        }

        public override void SetDefaults()
        {
            projectile.Size = new Vector2(40);
            projectile.aiStyle = 1;

            projectile.friendly = true;

            projectile.penetrate = -1;

            projectile.ignoreWater = true;
            projectile.tileCollide = true;

            aiType = ProjectileID.FrostWave;
        }
    }
}