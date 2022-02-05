using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using MTU.Players;
using MTU.Items.Weapons;

namespace MTU.Items.Accesories
{
    [AutoloadEquip(EquipType.Back)]
    class HawkeyesQuiver : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Hawkeye's Quiver");
            Tooltip.SetDefault("Using Hawkeye's bow with this quiver equipped will randomly transform wooden arrows into stronger arrows!");
        }
        public override void SetDefaults()
        {
            item.width = 30;
            item.height = 30;
            item.rare = ItemRarityID.LightPurple;
            item.value = Item.sellPrice(gold: 1, silver: 25);
            item.accessory = true;

            
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.rangedDamageMult += 0.10f;
            player.rangedCrit += 5;
            ModContent.GetInstance<HawkeyesBow>().item.shootSpeed *= 2;
            ModContent.GetInstance<HawkeyesBow>().item.damage = 45;
            ModContent.GetInstance<PlayerOne>().hasHawkQuiver = true;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.MagicQuiver, 1);
            recipe.AddIngredient(ItemID.MeteoriteBar, 10);
            recipe.AddIngredient(ItemID.HellstoneBar, 10);
            recipe.AddTile(ItemID.Hellforge);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
