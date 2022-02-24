using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using MTU.Items.Buffs;
using Microsoft.Xna.Framework;

namespace MTU.Players
{
    public class PlayerOne : ModPlayer
    {
        public bool hasHawkQuiver, hasAether, hasCaptain, hasChaosBuff, hasSoldierBuff, hasAgentBuff;
        public bool tryMutant, hasFrenziedBuff, hasSwiftBuff, hasResilientBuff;
        public float mutSpeed = 1.1f, mutDefense = 5, mutDamage = 1.1f;
        public int baseFlightTime;

        // 0: king slime  1: eye  2: EOF or Brain  3: Queen Bee  4: Skeletron  5: WoF  6: Twins  7: Destroyer 
        // 8: Skeletron Prime  9: Plantera  10: Golem  11: Fishron 12: cultist  13: moonlord
        public int[] bossesKilled = new int[14];

        public override void Initialize()
        {
            hasChaosBuff = false;
            hasSoldierBuff = false;
            hasAgentBuff = false;
            tryMutant = false;
            hasFrenziedBuff = false;
            hasSwiftBuff = false;
            hasResilientBuff = false;
            mutSpeed = 1.1f;
            mutDefense = 5;
            mutDamage = 1.1f;
            bossesKilled = new int[14];
            baseFlightTime = player.rocketTimeMax;
        }

        public override void Load(TagCompound tag)
        {
            hasChaosBuff = tag.GetBool("hasChaosBuff");
            hasSoldierBuff = tag.GetBool("hasSoldierBuff");
            hasAgentBuff = tag.GetBool("hasAgentBuff");
            tryMutant = tag.GetBool("isMutant");
            hasFrenziedBuff = tag.GetBool("hasFrenziedBuff");
            hasSwiftBuff = tag.GetBool("hasSwiftBuff");
            hasResilientBuff = tag.GetBool("hasResilientBuff");
            mutSpeed = tag.GetFloat("mutSpeed");
            mutDefense = tag.GetFloat("mutDefense");
            mutDamage = tag.GetFloat("mutDamage");
            bossesKilled = tag.GetIntArray("bossesKilled");
            baseFlightTime = tag.GetInt("baseFlightTime");
        }

        public override TagCompound Save()
        {
            return new TagCompound
            {
                {"hasChaosBuff", hasChaosBuff },
                {"hasSoldierBuff", hasSoldierBuff },
                {"hasAgentBuff", hasAgentBuff },
                {"isMutant", tryMutant },
                {"hasFrenziedBuff", hasFrenziedBuff },
                {"hasSwiftBuff", hasSwiftBuff },
                {"hasResilientBuff", hasResilientBuff },
                {"mutSpeed", mutSpeed },
                {"mutDefense", mutDefense },
                {"mutDamage", mutDamage },
                {"bossesKilled", bossesKilled },
                {"baseFlightTime", baseFlightTime }
            };

        }

        public override void PreUpdate()
        {
            if (hasChaosBuff)
            {
                player.AddBuff(ModContent.BuffType<ChaosVessel>(), 2);
            }
            if (hasSoldierBuff)
            {
                player.AddBuff(ModContent.BuffType<SuperSoldier>(), 2);
            }
            if (hasAgentBuff)
            {
                player.AddBuff(ModContent.BuffType<SecretAgent>(), 2);
            }
            if (hasFrenziedBuff)
            {
                player.AddBuff(ModContent.BuffType<FrenziedMutant>(), 2);
            }
            if (hasSwiftBuff)
            {
                player.AddBuff(ModContent.BuffType<SwiftMutant>(), 2);
            }
            if (hasResilientBuff)
            {
                player.AddBuff(ModContent.BuffType<ResilientMutant>(), 2);
            }
        }

        public bool GetHasHawkQuiver()
        {
			return hasHawkQuiver;
        }
        public override void OnHitByNPC(NPC npc, int damage, bool crit)
        {
            if (hasAether)
            {
                int proj = Projectile.NewProjectile(npc.position, new Vector2(0,0), ProjectileID.SolarWhipSwordExplosion, 7, 0, 1);
                Main.projectile[proj].friendly = true;
                Main.projectile[proj].timeLeft = 3;
                npc.StrikeNPC(damage * 10, 0, 0);
            }
        }
        public override void ResetEffects()
        {
            hasCaptain = false;
            hasAether = false;
            player.rocketTimeMax = baseFlightTime;
        }

        public override void OnEnterWorld(Player player)
        {
            int var = Main.rand.Next(3);
            if (var == 0 && !tryMutant)
            {
                var = Main.rand.Next(3);
                if (var == 0)
                {
                    hasFrenziedBuff = true;
                }
                else if (var == 1)
                {
                    hasSwiftBuff = true;
                }
                else
                {
                    hasResilientBuff = true;
                }
            }

            tryMutant = true;

            if (bossesKilled.Length == 0)
            {
                bossesKilled = new int[14];
                mutSpeed = 1.1f;
                mutDefense = 5;
                mutDamage = 1.1f;
            }
        }
    }
}
