using Components;
using Managers;

namespace Office.Scripts {
    public class SaveButton : HoverableButton {
        protected override void Start() {
            base.Start();
            this.onClick.AddListener(SaveGameManager.Save);
        }
    }
}
