using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MTU.Content.Items.Armors
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
            player.statDefense += 2;
            player.AddBuff(BuffID.Slow, 2);
            base.UpdateArmorSet(player);
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.IronBar, 20);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}