using Components;
using Managers;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Office.Scripts {
    public class QuitButton : HoverableButton {
        protected override void Start() {
            base.Start();
            this.onClick.AddListener(PromptQuit);
        }

        private static void PromptQuit() {
            SceneManager.LoadScene(InternalScenesManager.MainMenu);
        }
    }
}
