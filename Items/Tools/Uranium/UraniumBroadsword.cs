using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using MTU.Items.Materials;

namespace MTU.Items.Tools.Uranium
{
    class UraniumBroadsword : ModItem
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Uranium Broadsword");
		}
		public override void SetDefaults()
		{
			item.damage = 13;
			item.melee = true;
			item.width = 40;
			item.height = 40;
			item.useTime = 20;
			item.useAnimation = 20;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.knockBack = 6;
			item.value = Item.sellPrice(silver: 1, copper: 60);
			item.rare = ItemRarityID.Green;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<Materials.Uranium>(), 30);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
