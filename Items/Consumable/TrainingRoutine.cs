using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using MTU.Players;
using MTU.Items.Materials;

namespace MTU.Items.Consumable
{
    class TrainingRoutine : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Training Routine");
            Tooltip.SetDefault("Practice makes the master");
        }

        public override void SetDefaults()
        {
            item.width = 24;
            item.height = 40;
            item.maxStack = 1;
            item.consumable = true;
            item.value = Item.sellPrice(gold: 25);
            item.rare = ItemRarityID.Red;
            item.useStyle = ItemUseStyleID.EatingUsing;
            item.useAnimation = 20;
            item.useTime = 20;
            item.useTurn = true;
            item.UseSound = SoundID.Item3;
            item.consumable = true;
        }

        public override bool UseItem(Player player)
        {
            if (!player.GetModPlayer<PlayerOne>().hasChaosBuff && !player.GetModPlayer<PlayerOne>().hasSoldierBuff && !player.GetModPlayer<PlayerOne>().hasAgentBuff)
            {
                Main.NewText(player.name + " became a Secret Agent!");
                player.GetModPlayer<PlayerOne>().hasAgentBuff = true;
            }
            else if (player.GetModPlayer<PlayerOne>().hasChaosBuff)
            {
                Main.NewText(player.name + " is already a Chaos Vessel!");
                player.Hurt(Terraria.DataStructures.PlayerDeathReason.ByCustomReason("Stop experimenting with your body!"), 50, 0);
            }
            else if (player.GetModPlayer<PlayerOne>().hasSoldierBuff)
            {
                Main.NewText(player.name + " is already a Super Soldier!");
                player.Hurt(Terraria.DataStructures.PlayerDeathReason.ByCustomReason("Stop experimenting with your body!"), 50, 0);
            }
            else if (player.GetModPlayer<PlayerOne>().hasAgentBuff)
            {
                Main.NewText(player.name + " is already a Secret Agent!");
                player.Hurt(Terraria.DataStructures.PlayerDeathReason.ByCustomReason("Stop experimenting with your body!"), 50, 0);
            }
            return true;
        }
    }
}
