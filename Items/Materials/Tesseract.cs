using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MTU.Items.Materials
{
    class Tesseract : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Tesseract");
            Tooltip.SetDefault("Space bends to its will");
        }

        public override void SetDefaults()
        {
            item.width = 30;
            item.height = 30;
            item.maxStack = 1;
            item.value = Item.sellPrice(platinum: 10);
            item.rare = ItemRarityID.Cyan;
            item.material = true;
        }
    }
}
