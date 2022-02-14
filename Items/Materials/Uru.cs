using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace MTU.Items.Materials
{
    class Uru : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Uru");
            Tooltip.SetDefault("The Darween's metal");
        }

        public override void SetDefaults()
        {
            item.width = 8;
            item.height = 8;
            item.maxStack = 999;
            item.consumable = true;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.useTime = 10;
            item.useAnimation = 10;
            item.createTile = mod.TileType("UruTile");
            item.autoReuse = true;
            item.material = true;
        }
    }
}
