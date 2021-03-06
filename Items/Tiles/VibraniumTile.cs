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
            Main.tileSpelunker[Type] = true;


            drop = mod.ItemType("Vibranium");
            dustType = DustID.Platinum;

            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Vibranium");

            AddMapEntry(Color.MediumPurple, name);

            minPick = 50;
        }
        public override void NumDust(int i, int j, bool fail, ref int num)
        {
            num = fail ? 1 : 3;
        }
    }
}
