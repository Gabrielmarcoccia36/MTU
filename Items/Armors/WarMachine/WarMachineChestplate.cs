using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using MTU.Items.Materials;

namespace MTU.Items.Armors.WarMachine
{
    [AutoloadEquip(EquipType.Body)]
    class WarMachineChestplate : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("War Machine Chestplate");
            Tooltip.SetDefault("8% increased ranged damage\n8% increased ranged critical");
        }

        public override void SetDefaults()
        {
            item.width = 34;
            item.height = 20;
            item.maxStack = 1;
            item.value = Item.sellPrice(gold: 10);
            item.rare = ItemRarityID.Green;
            item.defense = 18;
        }

        public override void UpdateEquip(Player player)
        {
            player.rangedDamage *= 1.08f;
            player.rangedCrit *= (int)1.08f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe1 = new ModRecipe(mod);
            recipe1.AddIngredient(ItemID.ChlorophyteBar, 32);
            recipe1.AddIngredient(ModContent.ItemType<ArcReactorI>(), 1);
            recipe1.AddTile(TileID.MythrilAnvil);
            recipe1.SetResult(this);
            recipe1.AddRecipe();
        }
    }
}
