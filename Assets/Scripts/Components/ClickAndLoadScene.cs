using Menu;
using UnityEditor;
using UnityEngine.SceneManagement;

namespace Components {
    public class ClickAndLoadScene : EntryHover {
        public SceneAsset SceneToLoad;

        protected override void OnClick() {
            SceneManager.LoadScene(this.SceneToLoad.name);
        }
    }
}
