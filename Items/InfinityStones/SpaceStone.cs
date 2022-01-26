using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MTU.Items.InfinityStones
{
    class SpaceStone : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Space Stone");
            Tooltip.SetDefault("Anywhere, anytime");
        }

        public override void SetDefaults()
        {
            item.width = 14;
            item.height = 14;
            item.maxStack = 1;
            item.value = Item.sellPrice(platinum: 10);
            item.rare = 11;
            item.useStyle = 1;
            item.useTime = 40;
            item.useAnimation = 20;
            item.material = true;
        }

        public override bool UseItem(Player player)
        {
            var mousePos = Main.screenPosition + new Vector2(Main.mouseX, Main.mouseY);
            if (!Collision.SolidCollision(mousePos, player.width, player.height))
            {
                player.Teleport(mousePos);
                player.AddBuff(8, 100);
                return true;
            }

            return true;
        }
    }
}
