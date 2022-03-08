using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MTU.Items.Armors.WarMachine
{
    [AutoloadEquip(EquipType.Legs)]
    class WarMachineLeggings : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("War Machine Leggings");
            Tooltip.SetDefault("10% increased movement speed\n14% increased ranged critical");
        }

        public override void SetDefaults()
        {
            item.width = 22;
            item.height = 18;
            item.value = Item.sellPrice(gold: 6);
            item.rare = ItemRarityID.Lime;
            item.defense = 12;
        }

        public override void UpdateEquip(Player player)
        {
            player.moveSpeed *= 1.1f;
            player.rangedCrit *= (int)1.14f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe1 = new ModRecipe(mod);
            recipe1.AddIngredient(ItemID.ChlorophyteBar, 26);
            recipe1.AddTile(TileID.MythrilAnvil);
            recipe1.SetResult(this);
            recipe1.AddRecipe();
        }
    }
}
