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
            var mplayer = player.GetModPlayer<PlayerOne>();

            if (player.altFunctionUse == 2)
            {
                Main.NewText("Resilient mutant: " + mplayer.hasResilientBuff);
                Main.NewText("Resilient defense: " + mplayer.mutDefense);
                Main.NewText("Swift mutant: " + mplayer.hasSwiftBuff);
                Main.NewText("Swift speed: " + mplayer.mutSpeed);
                Main.NewText("Frenzied mutant: " + mplayer.hasFrenziedBuff);
                Main.NewText("Frenzied damage: " + mplayer.mutDamage);
                Main.NewText("Collected souls: " + mplayer.collectedSouls);
                Main.NewText("Soul upgrades: " + mplayer.soulsUpgrade);
            }
            else
            {
                mplayer.hasChaosBuff = false;
                mplayer.hasSoldierBuff = false;
                mplayer.hasAgentBuff = false;
                mplayer.hasFrenziedBuff = false;
                mplayer.hasResilientBuff = false;
                mplayer.hasSwiftBuff = false;
                mplayer.tryMutant = false;
                mplayer.mutDamage = 1.1f;
                mplayer.mutSpeed = 1.1f;
                mplayer.mutDefense = 5;
                mplayer.collectedSouls = 0;
                mplayer.soulsUpgrade = 1.0f;

                for (int i = 0; i < mplayer.bossesKilled.Length; i++)
                {
                    mplayer.bossesKilled[i] = 0;
                }
                
            }
            return true;
        }
    }
}
