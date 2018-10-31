using System;
using Components;
using UnityEngine;
using UnityEngine.UI;

namespace Office.Scripts {
    /// <inheritdoc />
    /// <summary>
    /// This component manages the office scene. It:
    ///     <list type="bullet">
    ///        <item>Setup every button to hide the interface whenever the user clicks;</item>
    ///        <item>Add a given hovering sound to every button of the interface;</item>
    ///        <item>Add the given colors to the buttons;</item>
    ///        <item>Restore the interface whenever the cancel (Escape) key is hit.</item>
    ///     </list>
    /// </summary>
    public class OfficeSceneEventManager : MonoBehaviour {
        /// <summary>
        /// The canvas to control, from which we will get the buttons
        /// and toggle the visibility whenever the user requests it.
        /// </summary>
        public GameObject ManagedContainerCanvas;

        /// <summary>
        /// An array of closeable canvas that will get closed whenever
        /// the user asks to do so, thus, by clicking on "close" or the Cancel (escape) button.
        /// </summary>
        public Canvas[] CloseableCanvasToManage;

        /// <summary>
        /// The button(s) that will be used to close canvas to
        /// which need to get proper events assigned to.
        /// </summary>
        public Button[] CloseCanvasButtons;

        /// <summary>
        /// <see cref="ManagedContainerCanvas"/> buttons colors to be set.
        /// </summary>
        private static readonly ColorBlock ButtonsColorBlock = new ColorBlock() {
            normalColor = new Color32(byte.MaxValue, byte.MaxValue, byte.MaxValue, byte.MaxValue),
            highlightedColor = new Color32(10, 10, 10, 128),
            pressedColor = new Color32(200, 200, 200, byte.MaxValue),
            disabledColor = new Color32(200, 200, 200, 128),
            colorMultiplier = 1f,
            fadeDuration = 0.1f
        };

        /// <summary>
        /// The audio source component to invoke
        /// whenever the user hovers a button of <see cref="ManagedContainerCanvas"/>.
        /// </summary>
        private AudioSource _onHoverAudioSource;

        /// <summary>
        /// Toggle the given canvas's visibility (<see cref="ManagedContainerCanvas"/>).
        /// </summary>
        /// <param name="status"></param>
        private void ToggleInterface(bool status) {
            this.ManagedContainerCanvas.SetActive(status);
        }

        /// <summary>
        /// Close all closeable canvas if, and only if the buttons are hidden.
        /// </summary>
        private void CloseAllCanvas() {
            if (this.ManagedContainerCanvas.activeSelf) {
                return;
            }

            // Hide any canvas parent of this component
            foreach (var canvas in CloseableCanvasToManage) {
                canvas.gameObject.SetActive(false);
            }

            // Show the buttons back to the user
            this.ToggleInterface(true);
        }

        /// <summary>
        /// Whenever the user clicks on a button of <see cref="ManagedContainerCanvas"/>,
        /// is toggle <see cref="ManagedContainerCanvas"/>'s visibility.
        /// </summary>
        private void OnCanvasOpenerButtonClick() {
            this.ToggleInterface(false);
        }

        /// <summary>
        /// Whenever the user hovers a button of <see cref="ManagedContainerCanvas"/>,
        /// play the given <see cref="_onHoverAudioSource"/> sound.
        /// </summary>
        private void _onButtonHover() {
            this._onHoverAudioSource.Play();
        }

        /// <summary>
        /// Initialize the office scene event handling by:
        ///
        /// <list type="bullet">
        ///     <item>
        ///         Retrieving the set-up audio hover source;
        ///     </item>
        ///     <item>
        ///         Setting-up <see cref="ManagedContainerCanvas"/>
        ///         buttons events (click and hover) and colors.
        ///     </item>
        ///     <item>
        ///         Setting-up <see cref="CloseCanvasButtons"/>
        ///         buttons click events to close every closeable canvas.
        ///     </item>
        /// </list>
        ///
        /// </summary>
        /// <exception cref="NullReferenceException"></exception>
        private void Start () {
            // Retrieve the interface buttons
            var managedButtons =
                this.ManagedContainerCanvas.GetComponentsInChildren<HoverableButton>();

            // Retrieve the over audio source component
            this._onHoverAudioSource = this.GetComponent<AudioSource>();

            // Ensure the component is correctly set-up
            if (!this._onHoverAudioSource) {
                throw new NullReferenceException("Missing audio source component.");
            }

            // Set-up buttons events (click and hover) and colors
            foreach (var childButton in managedButtons) {
                childButton.onClick.AddListener(this.OnCanvasOpenerButtonClick);
                childButton.onHover.AddListener(this._onButtonHover);
                childButton.colors = ButtonsColorBlock;
            }

            foreach (var closeButton in this.CloseCanvasButtons) {
                closeButton.onClick.AddListener(this.CloseAllCanvas);
            }
        }

        /// <summary>
        /// Whenever the Cancel button is pressed and <see cref="ManagedContainerCanvas"/>
        /// is hidden, we show it again and hide the other opened canvas.
        /// </summary>
        private void Update () {
            if (Input.GetButtonUp("Cancel")) {
                this.CloseAllCanvas();
            }
        }
    }
}
