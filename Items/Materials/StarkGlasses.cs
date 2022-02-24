﻿using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MTU.Items.Materials
{
    class StarkGlasses : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Stark Glasses");
            Tooltip.SetDefault("Grants spelunker, hunter, and night vision");
        }
        public override void SetDefaults()
        {
            item.width = 28;
            item.height = 28;
            item.maxStack = 30;
            item.value = Item.sellPrice(silver: 15);
            item.rare = ItemRarityID.LightRed;
            item.material = true;
            item.consumable = true;
        }
        public override void OnConsumeItem(Player player)
        {
            player.AddBuff(BuffID.Spelunker, 300);
            player.AddBuff(BuffID.Hunter, 300);
            player.AddBuff(BuffID.NightOwl, 300);
        }
        public override void AddRecipes()
        {
            ModRecipe recipe1 = new ModRecipe(mod);
            recipe1.AddIngredient(ItemID.SpelunkerPotion, 1);
            recipe1.AddIngredient(ItemID.NightOwlPotion, 1);
            recipe1.AddIngredient(ItemID.HunterPotion, 1);
            recipe1.AddIngredient(ItemID.Lens, 2);
            recipe1.AddIngredient(ItemID.LeadBar, 5);
            recipe1.AddTile(TileID.Anvils);
            recipe1.SetResult(this);
            recipe1.AddRecipe();

            ModRecipe recipe2 = new ModRecipe(mod);
            recipe2.AddIngredient(ItemID.SpelunkerPotion, 1);
            recipe2.AddIngredient(ItemID.NightOwlPotion, 1);
            recipe2.AddIngredient(ItemID.HunterPotion, 1);
            recipe2.AddIngredient(ItemID.Lens, 2);
            recipe2.AddIngredient(ItemID.IronBar, 5);
            recipe2.AddTile(TileID.Anvils);
            recipe2.SetResult(this);
            recipe2.AddRecipe();
        }
    }
}
