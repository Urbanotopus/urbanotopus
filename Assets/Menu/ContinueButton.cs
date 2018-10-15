using Components;
using Managers;

namespace Menu {
    /// <summary>
    /// This class will load the latest game save
    /// if the user clicks on the element.
    ///
    /// But will do nothing and appear disabled to the user
    /// if there is no save at all. To recheck existing saves,
    /// the whole scene will need to be reloaded.
    /// </summary>
    public class ContinueButton : EntryHover {
        /// <summary>
        /// Retrieves the list of existing game saves,
        /// if not saves were found, it disables the element
        /// and no `OnClick` event will ever be fired during
        /// the game object's lifetime.
        /// </summary>
        private new void Start() {
            var saves = SaveGameManager.GetGameManager().ListSaves();
            if (saves == null || saves.Count < 1) {
                this.IsEnabled = false;
            }

            base.Start();
        }

        /// <summary>
        /// Loads the latest game save when the user click on the element.
        /// </summary>
        protected override void OnClick() {
            SaveGameManager.GetGameManager().LoadLatestGame();
        }
    }
}
