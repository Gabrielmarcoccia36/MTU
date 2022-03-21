using System;
using Terraria;
using Terraria.ModLoader;

namespace MTU.Items.Weapons.Runes
{
    /// <summary>
    /// Implements all the necessary backend to make a rune.
    /// </summary>
    public abstract class BaseRune : ModProjectile
    {
        /// <summary>Range of the rune in pixels. Works as a radius. Defaults to 500.</summary>
        internal virtual int Range => 500;

        /// <summary>Whether this rune applies to NPCs or not. Defaults to true.</summary>
        internal virtual bool ApplyToNPCs => true;

        /// <summary>Whether this rune applies to Players or not. Defaults to true.</summary>
        internal virtual bool ApplyToPlayers => true;

        public sealed override void SetDefaults()
        {
            projectile.width = 30;
            projectile.height = 30;
            projectile.magic = true;
            projectile.friendly = true;
            projectile.tileCollide = false;
            projectile.penetrate = -1;
            projectile.aiStyle = -1;
            projectile.timeLeft = 3600;

            SafeSetDefaults();
        }

        /// <summary>Allows you to modify the basic defaults of the rune if need be.</summary>
        internal virtual void SafeSetDefaults()
        {
        }

        public override bool CanDamage() => false;

        public sealed override void AI()
        {
            SafeAI();

            if (ApplyToNPCs)
            {
                for (int i = 0; i < Main.maxNPCs; ++i)
                {
                    NPC npc = Main.npc[i];

                    if (npc.active && npc.CanBeChasedBy() && npc.DistanceSQ(projectile.Center) < Range * Range)
                        NPCEffect(npc);
                }
            }

            if (ApplyToPlayers)
            {
                for (int i = 0; i < Main.maxPlayers; ++i)
                {
                    Player player = Main.player[i];

                    if (player.active && !player.dead && player.DistanceSQ(projectile.Center) < Range * Range)
                        PlayerEffect(player);
                }
            }
        }
        
        /// <summary>Allows you to add more AI functionality if need be. Defaults to a simple up down motion.</summary>
        internal virtual void SafeAI()
        {
            //projectile.velocity.Y = (float)Math.Sin(Main.time * 0.08f) * 0.4f;
        }

        /// <summary>Allows you to apply effect(s) to an NPC when they're close enough to the rune.</summary>
        /// <param name="npc">NPC to affect.</param>
        internal virtual void NPCEffect(NPC npc)
        {
        }

        /// <summary>Allows you to apply effect(s) to a Player when they're close enough to the rune.</summary>
        /// <param name="player">Player to affect.</param>
        internal virtual void PlayerEffect(Player player)
        {
        }
    }
}
