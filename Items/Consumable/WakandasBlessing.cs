using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.World.Generation;
using Microsoft.Xna.Framework;
using MTU.Items.Tiles;

namespace MTU.Items.Consumable
{
    class WakandasBlessing : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Wakanda's Blessing");
            Tooltip.SetDefault("Using this item will bless the world with Vibranium Ore!");
        }

        public override void SetDefaults()
        {
            item.width = 24;
            item.height = 40;
            item.maxStack = 1;
            item.consumable = true;
            item.value = Item.sellPrice(gold: 15);
            item.rare = ItemRarityID.LightPurple;
            item.useStyle = ItemUseStyleID.EatingUsing;
            item.useAnimation = 40;
            item.useTime = 40;
            item.useTurn = true;
            item.UseSound = SoundID.Item3;
            item.consumable = true;
        }

        public override bool UseItem(Player player)
        {
            if (!ModContent.GetInstance<MTUWorld>().GetHasVibranium())
            {
                Main.NewText("The world has been blessed with Vibranium!");

                for (int i = 0; i < (int)((double)(Main.maxTilesX * Main.maxTilesY) * 0.0004); i++)
                {
                    WorldGen.TileRunner(WorldGen.genRand.Next(0, Main.maxTilesX), WorldGen.genRand.Next((int)WorldGen.rockLayerLow, Main.maxTilesY), WorldGen.genRand.Next(6, 9), WorldGen.genRand.Next(6, 9), ModContent.TileType<VibraniumTile>());
                }

                ModContent.GetInstance<MTUWorld>().SetHasVibranium(true);
            }
            else
            {
                Main.NewText("This world already has Vibranium!");
            }
            return true;
        }
    }
}
