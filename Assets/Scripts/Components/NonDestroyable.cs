using UnityEngine;

namespace Components {
    /// <inheritdoc />
    /// <summary>
    /// Create a non destroyable game object, that will stay unique and never die.
    /// </summary>
    public class NonDestroyable : MonoBehaviour {
        /// <summary>
        /// Whether an instance of this component was already created or not.
        /// </summary>
        private static bool _created;

        /// <summary>
        /// If it's not already created, flag it as non-destroyable and flag it was created.
        /// Otherwise, destroy the game object.
        /// </summary>
        private void Start() {
            if (!_created) {
                DontDestroyOnLoad(this.gameObject);
                _created = true;
            }
            else {
                Destroy(this.gameObject);
            }
        }
    }
}
