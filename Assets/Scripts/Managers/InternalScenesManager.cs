using UnityEngine;
using UnityEngine.SceneManagement;

namespace Managers {
    /// <summary>
    /// The internal references of all the available scenes.
    /// Also controls the scene loading and the loading states,
    /// allowing async scene loadings that are not freezing the user's interface
    /// for better feedback.
    /// </summary>
    public class InternalScenesManager : MonoBehaviour {
        private static InternalScenesManager _instance;
        public static string MainMenu = "MainMenuScene";
        public static string Office = "OfficeScene";
        public static string VisualNovel = "VisualNovelScene";

        public Canvas LoadingCanvas;

        /// <summary>
        /// Loads a given scene,
        /// with a loading screen from a given canvas if any given.
        /// Falls over the default scene loading method if no canvas was given.
        /// </summary>
        /// <param name="name"></param>
        public static void LoadScene(string name) {
            Debug.LogFormat("Loading: {0}", name);

            if (_instance && _instance.LoadingCanvas) {
                _instance.LoadingCanvas.gameObject.SetActive(true);
                SceneManager.LoadSceneAsync(name);
            }
            else {
                SceneManager.LoadScene(name);
            }
        }

        /// <summary>
        /// Assign what scene manager component to look for
        /// to find a loading zone canvas.
        /// </summary>
        private void Start() {
            _instance = this;
        }
    }
}
