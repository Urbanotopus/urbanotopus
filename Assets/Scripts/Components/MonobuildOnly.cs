using System.Linq;
using UnityEngine;

namespace Components {
    /// <summary>
    /// Class that disables a game object on unsupported platforms: editors and WebGL.
    /// </summary>
    public class MonobuildOnly : MonoBehaviour {
        /// <summary>
        /// List of unsupported platforms.
        /// </summary>
        private static readonly RuntimePlatform[] UnsupportedPlatforms = {
            RuntimePlatform.WindowsEditor,
            RuntimePlatform.LinuxEditor,
            RuntimePlatform.OSXEditor,
            RuntimePlatform.WebGLPlayer
        };

        /// <summary>
        /// Disables a game object if the running platform is not supported.
        /// </summary>
        private void Awake() {
            if (UnsupportedPlatforms.Any(
                    platform => Application.platform == platform)
            ) {
                this.gameObject.SetActive(false);
            }
        }
    }
}
