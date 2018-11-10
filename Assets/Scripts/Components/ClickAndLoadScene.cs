using Managers;

namespace Components {
    /// <summary>
    /// This class will load a given scene (from the inspector fields)
    /// whenever the user clicks on the associated GUI game object.
    /// </summary>
    public class ClickAndLoadScene : EntryHover {
        /// <summary>
        /// The field for the inspector,
        /// to allow the developer to select a given scene
        /// to load whenever the user clicks on the element.
        /// </summary>
        public string SceneToLoad;

        /// <summary>
        /// Load the gaven scene when the user clicked on the element.
        /// </summary>
        protected override void OnClick() {
            InternalScenesManager.LoadScene(this.SceneToLoad);
        }
    }
}
