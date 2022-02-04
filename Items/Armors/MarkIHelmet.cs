using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using MTU.Items.Buffs;

namespace MTU.Items.Armors
{
    [AutoloadEquip(EquipType.Head)]
    class MarkIHelmet : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Mark I Helmet");
            Tooltip.SetDefault("Heavy, but efficient");
        }

        public override void SetDefaults()
        {
            item.width = 22;
            item.height = 22;
            item.maxStack = 1;
            item.value = Item.sellPrice(silver: 10);
            item.rare = ItemRarityID.Green;
            item.defense = 2;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ModContent.ItemType<MarkIChestplate>() && legs.type == ModContent.ItemType<MarkILeggings>();
        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "Defense incremented by 2 and Slow";
            player.AddBuff(mod.BuffType("MarkIBuff"), 2);
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
            recipe2.AddIngredient(ItemID.LeadBar, 20);
            recipe2.AddTile(TileID.Anvils);
            recipe2.SetResult(this);
            recipe2.AddRecipe();
        }
    }
}