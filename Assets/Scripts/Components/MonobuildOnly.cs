using System.Linq;
using UnityEngine;

namespace Components {
    public class MonobuildOnly : MonoBehaviour {
        private static readonly RuntimePlatform[] UnsupportedPlatforms = {
            RuntimePlatform.WindowsEditor,
            RuntimePlatform.LinuxEditor,
            RuntimePlatform.OSXEditor,
            RuntimePlatform.WebGLPlayer
        };

        private void Awake() {
            if (UnsupportedPlatforms.Any(
                    platform => Application.platform == platform)
            ) {
                this.gameObject.SetActive(false);
            }
        }
    }
}
