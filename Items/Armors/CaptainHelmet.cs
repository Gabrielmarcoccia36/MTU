using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using MTU.Players;
using MTU.Items.Materials;

namespace MTU.Items.Armors
{
    [AutoloadEquip(EquipType.Head)]
    class CaptainHelmet : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Captain America's Helmet");
            Tooltip.SetDefault("15% increased melee\n6% increased crit chance");
        }

        public override void SetDefaults()
        {
            item.width = 22;
            item.height = 18;
            item.maxStack = 1;
            item.value = Item.sellPrice(silver: 10);
            item.rare = ItemRarityID.LightPurple;
            item.defense = 13;
        }

        public override void UpdateEquip(Player player)
        {
            player.meleeDamage *= 1.15f;
            player.meleeCrit = 6;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ModContent.ItemType<CaptainChestplate>() && legs.type == ModContent.ItemType<CaptainLeggings>();
        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "Vibranium Shield Damage increased\n20% increased melee and movement speed";
            player.GetModPlayer<PlayerOne>().hasCaptain = true;
            player.meleeDamage *= 1.2f;
            player.moveSpeed *= 1.2f;
            base.UpdateArmorSet(player);
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<VibraniumBar>(), 14);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}