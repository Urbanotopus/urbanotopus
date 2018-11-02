using Components;
using Managers;
using UnityEditor;
using UnityEngine.SceneManagement;

namespace Menu {
    /// <inheritdoc />
    /// <summary>
    /// This class will load a game scene
    /// and reset the game data if the user clicks on the element.
    /// </summary>
    public class NewGameButton : ClickAndLoadScene {
        /// <summary>
        /// Loads a new game when the user click on the element,
        /// and reset any game state data.
        /// </summary>
        protected override void OnClick() {
            SaveGameManager.ResetData();
            base.OnClick();
        }
    }
}
