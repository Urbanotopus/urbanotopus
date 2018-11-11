using Components;
using Managers;

namespace Office.Scripts {
    /// <inheritdoc />
    /// <summary>
    /// The Quit button component of the office scene.
    /// Manages the action of leaving the scene.
    /// </summary>
    public class QuitButton : HoverableButton {
        /// <summary>
        /// Called on the scene initialization.
        /// Registers to open a prompt when the user clicks on the button.
        /// </summary>
        protected override void Start() {
            base.Start();
            this.onClick.AddListener(PromptQuit);
        }

        /// <summary>
        /// Prompt to quit the scene.
        /// </summary>
        public static void PromptQuit() {
            // TODO: we need to put a prompt canvas here
            InternalScenesManager.LoadScene(InternalScenesManager.MainMenu);
        }
    }
}
