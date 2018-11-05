using Components;
using Managers;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Menu {
    /// <inheritdoc />
    /// <summary>
    /// This class will load a game scene
    /// and reset the game data if the user clicks on the element.
    /// </summary>
    public class NewGameButton : EntryHover {
        /// <summary>
        /// The scene to load whenever the button is pressed.
        /// </summary>
        public TextAsset YarnSceneToLoad;

        /// <summary>
        /// Loads a new game when the user click on the element,
        /// and reset any game state data.
        /// </summary>
        protected override void OnClick() {
            SaveGameManager.ResetData();
            YarnSceneManager.CurrentYarnScript = this.YarnSceneToLoad;
            SceneManager.LoadScene(InternalScenesManager.VisualNovel);
        }
    }
}
