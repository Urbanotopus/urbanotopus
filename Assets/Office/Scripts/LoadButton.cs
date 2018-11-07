using Components;
using Managers;
using UnityEngine.SceneManagement;

namespace Office.Scripts {
    public class LoadButton : HoverableButton {
        protected override void Start() {
            base.Start();
            this.onClick.AddListener(LoadSaveGameAndReload);
        }

        private static void LoadSaveGameAndReload() {
            SaveGameManager.LoadLatest();
            SceneManager.LoadScene(InternalScenesManager.Office);
        }
    }
}
