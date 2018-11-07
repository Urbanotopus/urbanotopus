using System;
using Managers;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Components {
    /// <inheritdoc />
    /// <summary>
    /// This manages buttons targeting the opening of a Yarn script.
    /// This manager expects to be put as a child of a Unity UI Button
    /// and will launch a new scene whenever the button is clicked.
    /// </summary>
    public class SceneLoaderButton : MonoBehaviour {
        /// <summary>
        /// The scene that is capable of loading any supplied Yarn script.
        /// </summary>
        private const string _YARN_SCENE_LOADER = "VisualNovelScene";

        /// <summary>
        /// The scene to load whenever the button is pressed.
        /// </summary>
        public TextAsset YarnSceneToLoad;

        /// <summary>
        /// Register a button to load a given scene whenever the user clicks on it.
        /// </summary>
        ///
        /// <exception cref="NullReferenceException">
        /// If the button is not correctly configured (no yarn source script).
        /// </exception>
        private void Start() {
            if (this.YarnSceneToLoad == null) {
                throw new NullReferenceException("The Yarn script is not referenced.");
            }
            this.GetComponentInParent<Button>().onClick.AddListener(this.OnClick);
        }

        /// <summary>
        /// Load the Yarn manager (Visual Novel) scene.
        /// </summary>
        private void OnClick() {
            YarnSceneManager.CurrentYarnScript = this.YarnSceneToLoad;
            InternalScenesManager.LoadScene(_YARN_SCENE_LOADER);
        }
    }
}
