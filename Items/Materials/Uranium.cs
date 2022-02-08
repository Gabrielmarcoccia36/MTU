using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace MTU.Items.Materials
{
    class Uranium : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Uranium");
            Tooltip.SetDefault("It doesn't seem harmful...");
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
            item.createTile = mod.TileType("UraniumTile");
            item.autoReuse = true;
            item.material = true;
        }
    }
}
