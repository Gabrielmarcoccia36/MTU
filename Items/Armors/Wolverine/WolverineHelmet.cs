using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using MTU.Players;
using MTU.Items.Materials;

namespace MTU.Items.Armors.Wolverine
{
    [AutoloadEquip(EquipType.Head)]
    class WolverineHelmet : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Wolverine's Helmet");
            Tooltip.SetDefault("12% increased melee\n8% increased crit chance");
        }

        public override void SetDefaults()
        {
            item.width = 22;
            item.height = 18;
            item.maxStack = 1;
            item.value = Item.sellPrice(gold: 22, silver: 10);
            item.rare = ItemRarityID.Yellow;
            item.defense = 12;
        }

        public override void UpdateEquip(Player player)
        {
            player.meleeDamage *= 1.12f;
            player.meleeCrit += 8;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ModContent.ItemType<WolverineChestplate>() && legs.type == ModContent.ItemType<WolverineLeggings>();
        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "25% increased melee and movement speed\nLife regen is five times stronger";
            player.meleeDamage *= 1.2f;
            player.moveSpeed *= 1.2f;
            player.lifeRegen *= 5;
            base.UpdateArmorSet(player);
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<AdamantiumBar>(), 14);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}