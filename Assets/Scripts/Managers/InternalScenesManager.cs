using UnityEngine;
using UnityEngine.SceneManagement;

namespace Managers {
    public class InternalScenesManager : MonoBehaviour {
        private static InternalScenesManager _instance;

        public const string MainMenu = "MainMenuScene";
        public const string Office = "OfficeScene";
        public const string VisualNovel = "VisualNovelScene";

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
        /// Whenever a scene is fully loaded, disable the loading area.
        /// </summary>
        /// <param name="scene">Inherited, unused.</param>
        /// <param name="mode">Inherited, unused.</param>
        private static void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
            _instance.LoadingCanvas.gameObject.SetActive(false);
        }

        /// <summary>
        /// Assign what scene manager component to look for
        /// to find a loading zone canvas.
        /// </summary>
        private void Start() {
            if (!_instance) {
                DontDestroyOnLoad(this.gameObject);
                _instance = this;
                SceneManager.sceneLoaded += OnSceneLoaded;
            }
            else {
                Destroy(this.gameObject);
            }
        }
    }
}
