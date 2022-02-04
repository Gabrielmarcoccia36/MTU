using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MTU.Items.Materials
{
    class Aether : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Aether");
            Tooltip.SetDefault("It looks alive");
        }
        public override void SetDefaults()
        {
            item.width = 23;
            item.height = 23;
            item.maxStack = 1;
            item.value = Item.sellPrice(platinum: 10);
            item.rare = ItemRarityID.Cyan;
            item.material = true;
            item.accessory = true;
        }
    }
}
