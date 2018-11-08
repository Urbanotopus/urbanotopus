using Components;
using Managers;

namespace Office.Scripts {
    /// <inheritdoc />
    /// <summary>
    /// The Save button component of the office scene.
    /// Manages the action of doing a quick save.
    /// </summary>
    public class SaveButton : HoverableButton {
        /// <summary>
        /// Called on the scene initialization.
        /// Registers a click event on the button that will save the game.
        /// </summary>
        protected override void Start() {
            base.Start();
            this.onClick.AddListener(SaveGameManager.Save);
        }
    }
}
