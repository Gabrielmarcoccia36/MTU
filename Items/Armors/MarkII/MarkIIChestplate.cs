using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using MTU.Items.Materials;

namespace MTU.Items.Armors.MarkII
{
    [AutoloadEquip(EquipType.Body)]
    class MarkIIChestplate : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Mark II Chestplate");
            Tooltip.SetDefault("6% increased damage\n5% increased critical");
        }

        public override void SetDefaults()
        {
            item.width = 34;
            item.height = 20;
            item.maxStack = 1;
            item.value = Item.sellPrice(gold: 10);
            item.rare = ItemRarityID.Lime;
            item.defense = 24;
        }

        public override void UpdateEquip(Player player)
        {
            player.allDamage *= 1.06f;
            player.meleeCrit *= (int)1.05f;
            player.magicCrit *= (int)1.05f;
            player.rangedCrit *= (int)1.05f;
            player.thrownCrit *= (int)1.05f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe1 = new ModRecipe(mod);
            recipe1.AddIngredient(ItemID.ChlorophyteBar, 30);
            recipe1.AddIngredient(ModContent.ItemType<ArcReactorII>(), 1);
            recipe1.AddTile(TileID.MythrilAnvil);
            recipe1.SetResult(this);
            recipe1.AddRecipe();
        }
    }
}
