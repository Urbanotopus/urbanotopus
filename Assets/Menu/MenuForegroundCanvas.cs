using UnityEngine;

namespace Menu {
    public class MenuForegroundCanvas : MonoBehaviour {
        /// <summary>
        /// The main menu options container, it will allow to toggle the visibility.
        /// </summary>
        public GameObject MainMenu;

        /// <summary>
        /// When the option canvas gets displayed, hide the main menu.
        /// </summary>
        private void OnEnable() {
            this.MainMenu.SetActive(false);
        }

        /// <summary>
        /// When the option canvas gets hidden, restore the main menu.
        /// </summary>
        private void OnDisable() {
            this.MainMenu.SetActive(true);
        }
    }
}
