﻿using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using MTU.Players;

namespace MTU.Items.Accesories
{
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
            player.rangedDamageMult += 0.15f;
            player.rangedCrit += 5;
            ModContent.GetInstance<PlayerOne>().hasHawkQuiver = true;
        }

        

        public override void AddRecipes()
        {

        }
    }
}
