using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using MTU.Players;
using MTU.Items.Buffs;

namespace MTU.Items.Armors
{
    [AutoloadEquip(EquipType.Head)]
    class CaptainHelmet : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Captain America Helmet");
            Tooltip.SetDefault("Feel the History");
        }

        public override void SetDefaults()
        {
            item.width = 22;
            item.height = 18;
            item.maxStack = 1;
            item.value = Item.sellPrice(silver: 10);
            item.rare = ItemRarityID.Green;
            item.defense = 2;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ModContent.ItemType<CaptainChestplate>() && legs.type == ModContent.ItemType<CaptainLeggings>();
        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "Shields Damage increased";
            ModContent.GetInstance<PlayerOne>().hasCaptain = true;
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