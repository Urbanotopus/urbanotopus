using Menu;
using Application = UnityEngine.Application;

namespace Components {
    public class ClickAndExit : EntryHover {
        protected override void OnClick() {
            Application.Quit();
        }
    }
}
