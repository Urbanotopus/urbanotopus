using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Managers {
    /// <summary>
    /// This class manages the game's debug features.
    /// This game object never dies on load and ensure its uniqueness.
    /// </summary>
    /// <inheritdoc />
    public class BackgroundGameManager : MonoBehaviour {
        /// <summary>
        /// The scene to load when the user hits F12.
        /// </summary>
        public SceneAsset DebugScene;

        /// <summary>
        /// True if an instance of this game object was created.
        /// Ensuring its uniqueness.
        /// </summary>
        private static bool _created;

        /// <summary>
        /// If it doesn't exist yet, it flags itself as existing
        /// and as not to be destroyed on load (no matter what).
        ///
        /// Otherwise, it flags itself as to be killed (destroyed).
        /// </summary>
        private void Awake() {
            if (!_created) {
                DontDestroyOnLoad(this.gameObject);
                _created = true;
            }
            else {
                Destroy(this.gameObject);
            }
        }

        /// <summary>
        /// If the user:
        /// <list type="bullet">
        ///    <item>
        ///         <term>Hits F12</term>
        ///         <description>It loads the assigned debug scene.</description>
        ///     </item>
        ///    <item>
        ///         <term>Hits F6</term>
        ///         <description>It saves the game's state.</description>
        ///     </item>
        ///    <item>
        ///         <term>Hits F7</term>
        ///         <description>It loads the game's state.</description>
        ///     </item>
        ///    <item>
        ///         <term>Hits F8</term>
        ///         <description>Deletes the saved game's state.</description>
        ///     </item>
        /// </list>
        /// </summary>
        private void FixedUpdate() {
            if (Input.GetKey (KeyCode.F12)) {
                SceneManager.LoadScene(this.DebugScene.name);
            }
            else if (Input.GetKey(KeyCode.F6)) {
                SaveGameManager.Save();
            }
            else if (Input.GetKey(KeyCode.F7)) {
                SaveGameManager.LoadLatest();
            }
            else if (Input.GetKey(KeyCode.F8)) {
                File.Delete(SaveGameManager.SavePath);
            }
            else if (Input.GetKey(KeyCode.F9)) {
                Debug.Log(SaveGameManager.GetCurrentGame().ChoiceHistory);
            }
        }
    }
}
