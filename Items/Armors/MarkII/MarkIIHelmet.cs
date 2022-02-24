using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using MTU.Items.Materials;

namespace MTU.Items.Armors.MarkII
{
    [AutoloadEquip(EquipType.Head)]
    class MarkIIHelmet : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Mark II Helmet");
            Tooltip.SetDefault("14% increased damage");
        }

        public override void SetDefaults()
        {
            item.width = 22;
            item.height = 18;
            item.maxStack = 1;
            item.value = Item.sellPrice(gold: 10);
            item.rare = ItemRarityID.Green;
            item.defense = 18;
        }

        public override void UpdateEquip(Player player)
        {
            player.allDamage *= 1.14f;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ModContent.ItemType<MarkIIChestplate>() && legs.type == ModContent.ItemType<MarkIILeggings>();
        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "Grants Mark II Buff";
            player.AddBuff(mod.BuffType("MarkIIBuff"), 2);
            base.UpdateArmorSet(player);
        }

        public override void AddRecipes()
        {
            ModRecipe recipe1 = new ModRecipe(mod);
            recipe1.AddIngredient(ItemID.IronBar, 20);
            recipe1.AddTile(TileID.Anvils);
            recipe1.SetResult(this);
            recipe1.AddRecipe();

            ModRecipe recipe2 = new ModRecipe(mod);
            recipe2.AddIngredient(ItemID.ChlorophyteBar, 20);
            recipe1.AddIngredient(ModContent.ItemType<StarkGlasses>(), 1);
            recipe2.AddTile(TileID.MythrilAnvil);
            recipe2.SetResult(this);
            recipe2.AddRecipe();
        }
    }
}
