using Components;
using Managers;
using UnityEngine.SceneManagement;

namespace Office.Scripts {
    /// <inheritdoc />
    /// <summary>
    /// The Load button component of the office scene.
    /// Manages the action of loading a quick save.
    /// </summary>
    public class LoadButton : HoverableButton {
        /// <summary>
        /// The load button of the 'Office' scene.
        /// Called when this component gets initialized,
        /// it instructs the base instance to call <see cref="LoadSaveGameAndReload"/>,
        /// which loads the latest save game and reload the scene (the office).
        /// </summary>
        protected override void Start() {
            base.Start();
            this.onClick.AddListener(LoadSaveGameAndReload);
        }

        /// <summary>
        /// Load the latest save game (if any), and reload the scene (the Office).
        /// </summary>
        private static void LoadSaveGameAndReload() {
            SaveGameManager.LoadLatest();
            SceneManager.LoadScene(InternalScenesManager.Office);
        }
    }
}
