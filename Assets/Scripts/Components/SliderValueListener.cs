using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

namespace Components {
    /// <inheritdoc />
    /// <summary>
    /// A game component that listens a given slider to give feedback on a text UI object.
    /// </summary>
    public class SliderValueListener : MonoBehaviour {
        public Slider TargetSlider;
        public Text TargetText;

        /// <summary>
        /// Register a value changed listener that will trigger the feedback,
        /// and manually trigger the feedback to force a base value.
        /// </summary>
        private void Start() {
            this.TargetSlider.onValueChanged.AddListener(this.OnValueChanged);
            this.OnValueChanged(this.TargetSlider.value);
        }

        /// <summary>
        /// Write the received feedback value of the slider to a given text object.
        /// </summary>
        /// <param name="newValue"></param>
        private void OnValueChanged(float newValue) {
            this.TargetText.text = newValue.ToString(CultureInfo.CurrentCulture);
        }
    }
}
