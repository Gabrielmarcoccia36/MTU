using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using MTU.Players;
using MTU.Items.Materials;

namespace MTU.Items.Consumable
{
    class ResetBuffs : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Reset Buffs");
            Tooltip.SetDefault("Debug Item");
        }

        public override void SetDefaults()
        {
            item.width = 24;
            item.height = 40;
            item.maxStack = 1;
            item.rare = ItemRarityID.Red;
            item.useStyle = ItemUseStyleID.EatingUsing;
            item.useAnimation = 40;
            item.useTime = 40;
            item.useTurn = true;
            item.UseSound = SoundID.Item3;
        }
        public override bool AltFunctionUse(Player player)
        {
            return true;
        }
        public override bool CanUseItem(Player player)
        {
            if (player.altFunctionUse == 2)
            {
                Main.NewText("Resilient mutant: " + player.GetModPlayer<PlayerOne>().hasResilientBuff);
                Main.NewText("Resilient defense: " + player.GetModPlayer<PlayerOne>().mutDefense);
                Main.NewText("Swift mutant: " + player.GetModPlayer<PlayerOne>().hasSwiftBuff);
                Main.NewText("Swift speed: " + player.GetModPlayer<PlayerOne>().mutSpeed);
                Main.NewText("Frenzied mutant: " + player.GetModPlayer<PlayerOne>().hasFrenziedBuff);
                Main.NewText("Frenzied damage: " + player.GetModPlayer<PlayerOne>().mutDamage);

                Main.NewText(player.GetModPlayer<PlayerOne>().bossesKilled.Length);
                for (int i = 0; i < 3; i++)
                {
                    if (player.GetModPlayer<PlayerOne>().bossesKilled[i] == 1)
                    {
                        Main.NewText("Boss " + i + " defeated");
                    }
                    else
                    {
                        Main.NewText("Boss " + i + " alive");
                    }
                }
            }
            else
            {
                player.GetModPlayer<PlayerOne>().hasChaosBuff = false;
                player.GetModPlayer<PlayerOne>().hasSoldierBuff = false;
                player.GetModPlayer<PlayerOne>().hasAgentBuff = false;
                player.GetModPlayer<PlayerOne>().hasFrenziedBuff = false;
                player.GetModPlayer<PlayerOne>().hasResilientBuff = false;
                player.GetModPlayer<PlayerOne>().hasSwiftBuff = false;
                player.GetModPlayer<PlayerOne>().tryMutant = false;
                player.GetModPlayer<PlayerOne>().mutDamage = 1.1f;
                player.GetModPlayer<PlayerOne>().mutSpeed = 1.1f;
                player.GetModPlayer<PlayerOne>().mutDefense = 5;

                for (int i = 0; i < player.GetModPlayer<PlayerOne>().bossesKilled.Length; i++)
                {
                    player.GetModPlayer<PlayerOne>().bossesKilled[i] = 0;
                }
                
            }
            return true;
        }
    }
}
