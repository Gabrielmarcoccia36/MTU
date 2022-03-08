using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using MTU.Items.Materials;

namespace MTU.Items.Armors.WarMachine
{
    [AutoloadEquip(EquipType.Head)]
    class WarMachineHelmet : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("War Machine Helmet");
            Tooltip.SetDefault("18% increased ranged damage\n25% chance not to consume ammo");
        }

        public override void SetDefaults()
        {
            item.width = 22;
            item.height = 18;
            item.maxStack = 1;
            item.value = Item.sellPrice(gold: 10);
            item.rare = ItemRarityID.Lime;
            item.defense = 16;
        }

        public override void UpdateEquip(Player player)
        {
            player.rangedDamage *= 1.18f;
        }
        public override bool ConsumeAmmo(Player player)
        {
            return Main.rand.NextFloat() >= .25f;
        }
        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ModContent.ItemType<WarMachineChestplate>() && legs.type == ModContent.ItemType<WarMachineLeggings>();
        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "Grants War Machine Buff";
            player.AddBuff(mod.BuffType("WarMachineBuff"), 2);
            base.UpdateArmorSet(player);
        }

        public override void AddRecipes()
        {
            ModRecipe recipe2 = new ModRecipe(mod);
            recipe2.AddIngredient(ItemID.ChlorophyteBar, 23);
            recipe2.AddIngredient(ModContent.ItemType<StarkGlasses>(), 1);
            recipe2.AddTile(TileID.MythrilAnvil);
            recipe2.SetResult(this);
            recipe2.AddRecipe();
        }
    }
}
