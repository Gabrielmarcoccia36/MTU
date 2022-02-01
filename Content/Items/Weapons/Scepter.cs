using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MTU.Content.Items.Weapons
{
    class Scepter : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Sceptre");
            Tooltip.SetDefault("Make the Mortals bow");
            Item.staff[item.type] = true;
        }

        public override void SetDefaults()
        {
            item.damage = 120;
            item.magic = true;
            item.mana = 5;
            item.width = 35;
            item.height = 35;
            item.maxStack = 1;
            item.value = Item.sellPrice(platinum: 10);
            item.rare = ItemRarityID.Cyan;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.noMelee = false;
            item.useTime = 40;
            item.useAnimation = 40;
            item.useTurn = true;
            item.knockBack = 5;
            item.autoReuse = true;
            item.shootSpeed = 30f;
            item.shoot = ProjectileID.ChargedBlasterOrb;
            item.material = true;
        }

    }
}