using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Components {
    /// <summary>
    /// A gameobject managing a button that ignores the overlaping UI objects.
    /// It detects over and click from the button position and the cursor/ pointer
    /// position.
    /// </summary>
    public class UIOverlappingButton : MonoBehaviour {
        /// <summary>
        /// The attached <see cref="GraphicRaycaster"/> component.
        /// </summary>
        private GraphicRaycaster _raycaster;

        /// <summary>
        /// The attached <see cref="PointerEventData"/> component.
        /// </summary>
        private PointerEventData _pointerEventData;

        /// <summary>
        /// The attached <see cref="EventSystem"/> component.
        /// </summary>
        private EventSystem _eventSystem;

        /// <summary>
        /// Initialize this object with the attached <see cref="GraphicRaycaster"/> and
        /// <see cref="EventSystem"/> game objects.
        /// </summary>
        private void Start() {
            this._raycaster = this.GetComponent<GraphicRaycaster>();
            this._eventSystem = this.GetComponent<EventSystem>();
        }

        /// <summary>
        /// Invoke the <see cref="Button.onClick"/> event whenever the user
        /// is pushing the mouse button over the GUI button.
        /// </summary>
        private void Update() {
            // Do nothing if the user is not clicking
            if (!Input.GetKeyUp(KeyCode.Mouse0)) {
                return;
            }

            // Where we will store the raycasting results
            var results = new List<RaycastResult>();

            // Retrieve the trigger event
            this._pointerEventData = new PointerEventData(this._eventSystem) {
                position = Input.mousePosition
            };

            // Retrieve the raycasting results
            this._raycaster.Raycast(this._pointerEventData, results);

            // If there was raycasting events over this button,
            // invoke the button's onclick event
            if (results.Count > 0) {
                this.gameObject.GetComponent<Button>().onClick.Invoke();
            }
        }
    }
}
