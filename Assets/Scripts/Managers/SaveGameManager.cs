using Boo.Lang;
using UnityEngine;

namespace Managers {
    /// <summary>
    /// This class manages game saves and ensure its game object own
    /// uniqueness.
    /// </summary>
    /// <inheritdoc />
    public class SaveGameManager : MonoBehaviour {
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
        /// Finds and returns the existing game save manager.
        /// </summary>
        /// <returns>The existing self game object.</returns>
        public static SaveGameManager GetGameManager() {
            return FindObjectOfType<SaveGameManager>();
        }

        /// <summary>
        /// Retrieves the list of game saves and returns thems.
        /// </summary>
        /// <returns>The list of existing named game saves.</returns>
        public List<int> ListSaves() {
            // FIXME: implement me (see #9)
            return new List<int>();
        }

        /// <summary>
        /// Loads the latest game save.
        /// </summary>
        public void LoadLatestGame() {
            // FIXME: implement me (see #9)
        }
    }
}
