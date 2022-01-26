using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MTU.Items.InfinityStones
{
    class SoulStone : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Soul Stone");
            Tooltip.SetDefault("A soul for a soul");
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
            player.AddBuff(9, 36000);
            player.AddBuff(17, 36000);

            return true;
        }
    }
}