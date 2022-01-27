using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria.ObjectData;

namespace MTU.Items.Tiles
{
    class VibraniumTile : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileMergeDirt[Type] = true;
            Main.tileLavaDeath[Type] = false;
            Main.tileShine[Type] = 1000;


            drop = mod.ItemType("ExampleTileItem");
            dustType = DustID.Platinum;

            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Vibranium");

            AddMapEntry(Color.AliceBlue);

            minPick = 50;
        }
        public override void NumDust(int i, int j, bool fail, ref int num)
        {
            num = fail ? 1 : 3;
        }

        public override bool Drop(int i, int j)
        {
            Tile t = Main.tile[i, j];
            Item.NewItem(i * 16, j * 16, 16, 16, ModContent.ItemType<Items.Materials.Vibranium>());

            return base.Drop(i, j);
        }
    }
}
