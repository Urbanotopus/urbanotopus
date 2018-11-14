using UnityEngine;

namespace Menu {
    /// <inheritdoc />
    /// <summary>
    /// This class manages a options canvas,
    /// and will disable itself if the user hits "Cancel" (e.g.: escape key).
    /// </summary>
    public class OptionsCanvas : MenuForegroundCanvas {
        /// <summary>
        /// Disable itself (<code>gameObject.SetActive(false)</code>)
        /// if the user hits "Cancel".
        /// </summary>
        private void Update() {
            if (Input.GetButtonUp("Cancel")) {
                this.gameObject.SetActive(false);
            }
        }
    }
}
