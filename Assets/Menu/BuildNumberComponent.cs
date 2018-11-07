using UnityEngine;

namespace Menu {
    /// <inheritdoc />
    /// <summary>
    /// A component that populates a text mesh with
    /// the build number on the main menu.
    /// </summary>
    [ExecuteInEditMode]
    public class BuildNumberComponent : MonoBehaviour {
        /// <summary>
        /// The latest release ID.
        /// </summary>
        public int BuildId;

        /// <summary>
        /// Populates a text mesh component with the build number.
        /// </summary>
        private void Start () {
            var textMesh = this.GetComponent<TextMesh>();
            if (!textMesh) {
                return;
            }

            textMesh.text = string.Format("Build #{0}", this.BuildId);
        }
    }
}
