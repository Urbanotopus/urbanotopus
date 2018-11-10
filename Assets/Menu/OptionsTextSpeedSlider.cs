using Managers;
using UnityEngine.UI;

namespace Menu {
    /// <inheritdoc />
    /// <summary>
    /// A slider component that manages a YarnSpinner text speed on the save game.
    /// </summary>
    public class OptionsTextSpeedSlider : Slider {
        /// <summary>
        /// Set the current speed as value on the slider when the component awakes.
        /// But make it human readable, instead of having the quickest speed on the left,
        /// put them on the right.
        /// </summary>
        protected override void OnEnable() {
            base.OnEnable();
            this.Set(1f - SaveGameManager.GetCurrentGame().TextSpeed, false);
        }

        /// <inheritdoc />
        /// <summary>
        /// Save the new value to the current save game whenever the value gets changed.
        /// </summary>
        /// <param name="input"></param>
        /// <param name="sendFeedBack"></param>
        protected override void Set(float input, bool sendFeedBack) {
            base.Set(input, sendFeedBack);
            if (sendFeedBack) {
                SaveGameManager.GetCurrentGame().TextSpeed = 1f - input;
            }
        }
    }
}
