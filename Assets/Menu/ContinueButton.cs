using Components;
using Managers;
using UnityEngine.SceneManagement;

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
        /// If no saves were found, it disables the element
        /// and no `OnClick` event will ever be fired during
        /// the game object's lifetime.
        /// </summary>
        private new void Start() {
            this.IsEnabled = SaveGameManager.SaveGameExists();
            base.Start();
        }

        /// <summary>
        /// Loads the latest game save when the user click on the element.
        /// </summary>
        protected override void OnClick() {
            SaveGameManager.LoadLatest();
            SceneManager.LoadScene(InternalScenesManager.Office);
        }
    }
}
