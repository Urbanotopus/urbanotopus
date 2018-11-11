using UnityEngine;

namespace Components {
    /// <inheritdoc />
    /// <summary>
    /// A component that handles a mouse hover (through a hit box)
    /// with a given color.
    /// The entry (component):
    /// <list type="bullet">
    ///     <item>Can play a sound when the user hovers.</item>
    ///     <item>Can be flagged disabled, and will gain a given color.</item>
    ///     <item>Support the trigger of a click event.</item>
    /// </list>
    /// </summary>
    public class EntryHover : MonoBehaviour {
        /// <summary>
        /// The background color for when the mouse is hovering the component.
        /// </summary>
        public Color HoverColor = Color.yellow;

        /// <summary>
        /// The background color for when the component is flagged as disabled.
        /// </summary>
        public Color DisabledColor = new Color(0.49f, 0.49f, 0.49f);

        /// <summary>
        /// The sound to play when the user hovers.
        /// </summary>
        private AudioSource _audioHoverSource;

        /// <summary>
        /// The renderer to apply material colors.
        /// </summary>
        private Renderer _renderer = new Renderer();

        /// <summary>
        /// The previous background color before hovering.
        /// </summary>
        private Color _inactiveColor = Color.gray;

        /// <summary>
        /// The current state of the component, a flag
        /// telling if the user is currently hovering the component or not.
        /// </summary>
        private bool _isHovering;

        /// <summary>
        /// Whether the component must be in disabled or enabled state (requires restart).
        /// </summary>
        protected bool IsEnabled = true;

        /// <summary>
        /// An event that gets fired whenever a click occurs.
        /// </summary>
        protected virtual void OnClick() {}

        /// <summary>
        /// Fired whenever the user release a click on the component.
        /// We make sure the user was hovering the button.
        /// </summary>
        private void OnMouseUp() {
            if (!this._isHovering) {
                return;
            }
            this.OnClick();
        }

        /// <summary>
        /// Set-up the component by retrieve every base component of the game object
        /// and setting the cursor as visible on the GUI.
        /// Then checking if whether or not we should put the disabled color
        /// if the button is disabled.
        /// </summary>
        protected void Start() {
            this._audioHoverSource = this.GetComponent<AudioSource>();
            this._renderer = this.GetComponent<Renderer>();
            Cursor.visible = true;

            if (!this.IsEnabled) {
                this._renderer.material.color = this.DisabledColor;
            }
        }

        /// <summary>
        /// Fired whenever the user starts hovering.
        /// This saves the current background color and replace it by the hover one.
        /// </summary>
        protected void ActivateHover() {
            this._inactiveColor = this._renderer.material.color;
            this._renderer.material.color = this.HoverColor;
        }

        /// <summary>
        /// Fired whenever the user stops hovering.
        /// This restore the previous background color.
        /// </summary>
        protected void DeactivateHover() {
            this._renderer.material.color = this._inactiveColor;
        }

        /// <summary>
        /// Fired whenever the user starts hovering the component.
        /// It ensures that the user wasn't already hovering it (double fire)
        /// and if the component is enabled or not, if it's not, it does nothing.
        ///
        /// Then, it plays a sounds and enter the hovering mode.
        /// </summary>
        private void OnMouseEnter() {
            // we need to ensure this is not being
            // called multiple times during an update
            if (this._isHovering || !this.IsEnabled) {
                return;
            }
            this.ActivateHover();
            this._isHovering = true;
            this._audioHoverSource.Play();
        }

        /// <summary>
        /// Fired whenever the user stops hovering the component.
        /// It ensures that the user was already hovering it.
        ///
        /// Then, exists the hovering mode.
        /// </summary>
        private void OnMouseExit() {
            if (!this._isHovering) {
                return;
            }

            this.DeactivateHover();
            this._isHovering = false;
        }
    }
}
