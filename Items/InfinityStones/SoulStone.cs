using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using MTU.Players;

namespace MTU.Items.InfinityStones
{
    class SoulStone : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Soul Stone");
            Tooltip.SetDefault("A soul for a soul\nUse to check how many collected souls");
        }

        public override void SetDefaults()
        {
            item.width = 14;
            item.height = 14;
            item.maxStack = 1;
            item.value = Item.sellPrice(platinum: 10);
            item.rare = ItemRarityID.Purple;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.useTime = 40;
            item.useAnimation = 20;
            item.material = true;
        }

        public override bool UseItem(Player player)
        {
            Main.NewText("Collected Souls: " + player.GetModPlayer<PlayerOne>().collectedSouls);
            Main.NewText("Soul Upgrades: " + player.GetModPlayer<PlayerOne>().soulsUpgrade);

            return true;
        }
    }
}