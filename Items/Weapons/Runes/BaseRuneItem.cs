using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MTU.Items.Weapons.Runes
{
    public abstract class BaseRuneItem : ModItem
    {
        internal abstract int RuneType { get; }

        public override void SetDefaults()
        {
            item.width = 30;
            item.height = 30;
            item.rare = ItemRarityID.LightPurple;
            item.value = Item.sellPrice(gold: 2);
            item.useTime = item.useAnimation = 30;
            item.useStyle = ItemUseStyleID.HoldingUp;
            item.autoReuse = true;
            item.UseSound = SoundID.Item5;
            item.magic = true;
            item.crit = 15;
            item.knockBack = 5f;
            item.noMelee = true;
            item.shootSpeed = 0f;
            item.shoot = RuneType;

            SafeSetDefaults();
        }

        /// <summary>Allows you to modify the basic defaults of the rune item if need be.</summary>
        internal virtual void SafeSetDefaults()
        {
        }

        public override bool CanUseItem(Player player) => player.ownedProjectileCounts[RuneType] == 0; //Only usable with 0 specific runes alive

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            position = Main.MouseWorld;

            return SafeShoot(player, ref position, ref speedX, ref speedY, ref type, ref damage, ref knockBack);
        }

        /// <summary>Allows you to modify the shoot values and stats of the rune if need be. Returns true by default.</summary>
        internal virtual bool SafeShoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            return true;
        }
    }
}
