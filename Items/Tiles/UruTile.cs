using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria.ObjectData;

namespace MTU.Items.Tiles
{
    class UruTile : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileMergeDirt[Type] = true;
            Main.tileLavaDeath[Type] = false;
            Main.tileShine[Type] = 1000;


            drop = mod.ItemType("Uru");
            dustType = DustID.Platinum;

            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Uru");

            AddMapEntry(Color.DarkGoldenrod, name);

            minPick = 80;
        }
        public override void NumDust(int i, int j, bool fail, ref int num)
        {
            num = fail ? 1 : 3;
        }
    }
}
