using Application = UnityEngine.Application;

namespace Components {
    /// <summary>
    /// This class exit the current Unity game
    /// whenever the user clicks on the associated GUI game object.
    /// </summary>
    public class ClickAndExit : EntryHover {
        /// <summary>
        /// Fired when the user clicks on the GUI object.
        /// This will exit the game.
        ///
        /// Note: this will do nothing if the game is running Unity's Game Editor.
        /// </summary>
        protected override void OnClick() {
            Application.Quit();
        }
    }
}
