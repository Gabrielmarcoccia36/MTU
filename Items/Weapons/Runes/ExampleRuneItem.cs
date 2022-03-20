using Terraria.ModLoader;

namespace MTU.Items.Weapons.Runes
{
    public class ExampleRuneItem : BaseRuneItem
    {
        internal override int RuneType => ModContent.ProjectileType<ExampleRune>();
    }
}
