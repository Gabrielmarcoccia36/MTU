using MTU.Content.Items.Tiles;
using System.Collections.Generic;
using Terraria;
using Terraria.GameContent.Generation;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.World.Generation;

namespace MTU
{
	class MTUWorld : ModWorld
	{
		private bool hasVibranium;
		public override void Initialize()
		{
			hasVibranium = false;
		}

		public override void Load(TagCompound tag)
		{
			hasVibranium = tag.GetBool("HasVibranium");
		}

		public override TagCompound Save()
		{
			return new TagCompound
			{
				{"HasVibranium", hasVibranium }
			};
		}

		public override void ModifyWorldGenTasks(List<GenPass> tasks, ref float totalWeight)
		{
			// Because world generation is like layering several images ontop of each other, we need to do some steps between the original world generation steps.

			// The first step is an Ore. Most vanilla ores are generated in a step called "Shinies", so for maximum compatibility, we will also do this.
			// First, we find out which step "Shinies" is.
			int ShiniesIndex = tasks.FindIndex(genpass => genpass.Name.Equals("Shinies"));
			if (ShiniesIndex != -1)
			{
				// Next, we insert our step directly after the original "Shinies" step. 
				// ExampleModOres is a method seen below.
				tasks.Insert(ShiniesIndex + 1, new PassLegacy("Uranium Ores", UraniumOres));
			}
		}

		private void UraniumOres(GenerationProgress progress)
		{
			progress.Message = "Generating Radioactive Materials";

			for (int i = 0; i < (int)((double)(Main.maxTilesX * Main.maxTilesY) * 6E-05); i++)
			{
				WorldGen.TileRunner(WorldGen.genRand.Next(0, Main.maxTilesX), WorldGen.genRand.Next((int)WorldGen.worldSurfaceLow, (int)WorldGen.worldSurfaceHigh), WorldGen.genRand.Next(4, 7), WorldGen.genRand.Next(3, 7), ModContent.TileType<UraniumTile>());
			}

			for (int i = 0; i < (int)((double)(Main.maxTilesX * Main.maxTilesY) * 8E-05); i++)
			{
				WorldGen.TileRunner(WorldGen.genRand.Next(0, Main.maxTilesX), WorldGen.genRand.Next((int)WorldGen.worldSurfaceHigh, (int)WorldGen.rockLayerHigh), WorldGen.genRand.Next(4, 8), WorldGen.genRand.Next(4, 8), ModContent.TileType<UraniumTile>());
			}

			for (int i = 0; i < (int)((double)(Main.maxTilesX * Main.maxTilesY) * 0.0002); i++)
			{
				WorldGen.TileRunner(WorldGen.genRand.Next(0, Main.maxTilesX), WorldGen.genRand.Next((int)WorldGen.rockLayerLow, Main.maxTilesY), WorldGen.genRand.Next(5, 9), WorldGen.genRand.Next(5, 9), ModContent.TileType<UraniumTile>());
			}
		}

		public bool GetHasVibranium()
        {
			return hasVibranium;
        }

		public void SetHasVibranium(bool var)
        {
			hasVibranium = var;
		}
	}
}
