using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MTU.Items.Consumable
{
    class Cheese : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Cheese");
            Tooltip.SetDefault("Cheese? Cheese!");
        }

        public override void SetDefaults()
        {
            item.width = 28;
            item.height = 24;
            item.maxStack = 99;
            item.consumable = true;
            item.value = Item.sellPrice(copper: 15);
            item.rare = ItemRarityID.White;
            item.useStyle = ItemUseStyleID.EatingUsing;
            item.useAnimation = 20;
            item.useTime = 20;
            item.useTurn = true;
            item.UseSound = SoundID.Item3;
            item.consumable = true;
        }

        public override bool UseItem(Player player)
        {
            player.AddBuff(BuffID.WellFed, 9000);

            return true;
        }
    }
}
