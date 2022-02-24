using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MTU.Items.Armors.MarkII
{
    [AutoloadEquip(EquipType.Legs)]
    class MarkIILeggings : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Mark II Leggings");
            Tooltip.SetDefault("5% increased movement speed\n8% increased critical");
        }

        public override void SetDefaults()
        {
            item.width = 22;
            item.height = 18;
            item.value = Item.sellPrice(gold: 6);
            item.rare = ItemRarityID.Green;
            item.defense = 12;
            item.crit = 8;
        }

        public override void UpdateEquip(Player player)
        {
            player.moveSpeed *= 1.05f;
            player.meleeCrit *= (int)1.08f;
            player.magicCrit *= (int)1.08f;
            player.rangedCrit *= (int)1.08f;
            player.thrownCrit *= (int)1.08f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe1 = new ModRecipe(mod);
            recipe1.AddIngredient(ItemID.ChlorophyteBar, 25);
            recipe1.AddTile(TileID.MythrilAnvil);
            recipe1.SetResult(this);
            recipe1.AddRecipe();
        }
    }
}
