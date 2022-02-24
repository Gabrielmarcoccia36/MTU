using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using MTU.NPCs;

namespace MTU.Items.Buffs
{
    class Irradiated : ModBuff
    {
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Irradiated");
			Description.SetDefault("Taking radiation damage");
			Main.debuff[Type] = true;
			Main.pvpBuff[Type] = true;
			Main.buffNoSave[Type] = true;
		}

		public override void Update(NPC npc, ref int buffIndex)
		{
			npc.GetGlobalNPC<MTUGlobalNPCEffects>().irradiated = true;
		}
	}
}
