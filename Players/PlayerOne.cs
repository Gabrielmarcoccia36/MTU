using Terraria;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace MTU.Players
{
    public class PlayerOne : ModPlayer
    {
        public bool hasHawkQuiver;

        public bool GetHasHawkQuiver()
        {
			return hasHawkQuiver;
        }		
	}
}
