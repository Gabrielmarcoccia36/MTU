using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MTU.Items
{
    class RealityStone : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Reality Stone");
            Tooltip.SetDefault("Reality is in your hands");
        }

        public override void SetDefaults()
        {
            item.width = 14;
            item.height = 14;
            item.maxStack = 1;
            item.value = Item.sellPrice(platinum: 10);
            item.rare = 11;
            item.useStyle = 4;
            item.useTime = 3;
            item.buffType = 18;
            item.buffTime = 36000;
        }
    }
}
