using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace Managers {
    /// <summary>
    /// This class manages game saves and ensure its game object own
    /// uniqueness.
    /// </summary>
    /// <inheritdoc />
    public class SaveGameManager : MonoBehaviour {
        /// <summary>
        /// The filename that the save game should have.
        /// </summary>
        private const string _SAVE_FILENAME = "save0001.dat";

        /// <summary>
        /// The local path where the save game should be located.
        /// The value get populated when the game object awakes.
        /// </summary>
        public static string SavePath;

        /// <summary>
        /// True if an instance of this game object was created.
        /// Ensuring its uniqueness.
        /// </summary>
        private static bool _created;

        /// <summary>
        /// Current loaded game state instance object.
        /// </summary>
        private static GameState _currentGame = new GameState();

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

                SavePath = Path.Combine(
                    Application.persistentDataPath, "savedGames.gd");
            }
            else {
                Destroy(this.gameObject);
            }
        }

        /// <summary>
        /// Return <code>True</code> if a save game is available
        /// to be loaded from on the hard drive.
        /// </summary>
        /// <returns></returns>
        public static bool SaveGameExists() {
            return File.Exists(SavePath);
        }

        /// <summary>
        /// Save the current game state to a save file game.
        /// </summary>
        public static void Save() {
            // Retrieve the game's local save path and create a new file.
            using (var fp = File.Create(SavePath)) {
                // Serialize the current game.
                new BinaryFormatter().Serialize(fp, _currentGame);
            }
        }

        /// <summary>
        /// Loads the latest game save.
        /// </summary>
        public static void LoadLatest() {
            // To reduce nesting, we return as we are nothing to do.
            if (!SaveGameExists()) {
                return;
            }

            // Open, and load the file for deserialization.
            using (var fp = File.Open(SavePath, FileMode.Open)) {
                _currentGame = (GameState) new BinaryFormatter().Deserialize(fp);
            }
        }
    }
}
