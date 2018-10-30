using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Components {
    /// <inheritdoc />
    /// <summary>
    /// A button component that is able to get hovering event registered to it.
    /// </summary>
    public class HoverableButton : Button {
        /// <summary>
        /// A <see cref="UnityEvent"/> event manager that allows users
        /// to register hovering events.
        /// </summary>
        private UnityEvent _onHover = new UnityEvent();

        /// <summary>
        ///   <para>UnityEvent that is triggered when the button is hovered.</para>
        /// </summary>
        public UnityEvent onHover // noqa
        {
            get {
                return this._onHover;
            }
            set {
                this._onHover = value;
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Fires the hover event whenever the mouse enters.
        /// </summary>
        /// <param name="eventData"></param>
        public override void OnPointerEnter(PointerEventData eventData) {
            this._onHover.Invoke();
            base.OnPointerEnter(eventData);
        }
    }
}
