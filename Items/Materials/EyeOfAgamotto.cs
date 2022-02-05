using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MTU.Items.Materials
{
    class EyeOfAgamotto : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Eye of Agamotto");
            Tooltip.SetDefault("Most powerful tool of a mystic arts practitioner\nGrants several buffs when worn");
        }

        public override void SetDefaults()
        {
            item.width = 30;
            item.height = 30;
            item.maxStack = 1;
            item.value = Item.sellPrice(platinum: 10);
            item.rare = ItemRarityID.Cyan;
            item.material = true;
            item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.AddBuff(2, 2);
            player.AddBuff(3, 2);
            player.AddBuff(6, 2);
            player.AddBuff(104, 2);
        }
    }
}
