using Components;
using Managers;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Menu {
    /// <inheritdoc />
    /// <summary>
    /// This class will show a options canvas if the user clicks on the element.
    /// </summary>
    public class OptionsButton : EntryHover {
        /// <summary>
        /// The option canvas to show whenever the button is pressed.
        /// </summary>
        public Canvas OptionsCanvas;

        /// <summary>
        /// Set visible the options container whenever the user clicks on the button.
        /// </summary>
        protected override void OnClick() {
            this.OptionsCanvas.gameObject.SetActive(true);
        }
    }
}
