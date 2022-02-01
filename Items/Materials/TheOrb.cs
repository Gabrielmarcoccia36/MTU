using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MTU.Items.Materials
{
    class TheOrb : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("The Orb");
            Tooltip.SetDefault("Feels odd to the touch");
        }

        public override void SetDefaults()
        {
            item.width = 22;
            item.height = 22;
            item.maxStack = 1;
            item.value = Item.sellPrice(platinum: 10);
            item.rare = ItemRarityID.Cyan;
            item.material = true;
        }

    }
}