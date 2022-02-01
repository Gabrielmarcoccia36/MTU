using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria.ObjectData;

namespace MTU.Items.Tiles
{
    class UraniumTile : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileMergeDirt[Type] = true;
            Main.tileLavaDeath[Type] = false;
            Main.tileShine[Type] = 1000;


            drop = mod.ItemType("Uranium");
            dustType = DustID.Platinum;

            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Uranium");

            AddMapEntry(Color.GreenYellow, name);

            minPick = 35;
        }
        public override void NumDust(int i, int j, bool fail, ref int num)
        {
            num = fail ? 1 : 3;
        }
    }
}
