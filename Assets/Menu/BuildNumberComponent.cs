using UnityEngine;

namespace Menu {
    [ExecuteInEditMode]
    public class BuildNumberComponent : MonoBehaviour {
        public int BuildId;

        private void Start () {
            var textMesh = this.GetComponent<TextMesh>();
            if (!textMesh) {
                return;
            }

            textMesh.text = string.Format("Build #{0}", this.BuildId);
        }
    }
}
