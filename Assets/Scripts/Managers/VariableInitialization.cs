using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Managers
{
    /// <summary>
    /// Ensures the uniqueness of the script manager.
    /// </summary>
    public class VariableInitialization : MonoBehaviour {
        private GameData _gameData;

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

        private void Start() {
            this._gameData= new GameData();
        }
    }

}
