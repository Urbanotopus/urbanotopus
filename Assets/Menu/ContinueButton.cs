using Managers;

namespace Menu {
    public class ContinueButton : EntryHover {
        private new void Start() {
            var saves = SaveGameManager.GetGameManager().ListSaves();
            if (saves == null || saves.Count < 1) {
                this.IsEnabled = false;
            }

            base.Start();
        }

        protected override void OnClick() {
        }
    }
}
