using Terraria.UI;

namespace MTU.UI.TimeStoneUI
{
    class MenuBar : UIState
    {
        public PlayButton playButton;

        public override void OnInitialize()
        {
            playButton = new PlayButton();

            Append(playButton);
        }
    }
}
