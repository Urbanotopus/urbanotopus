using System;
using UnityEngine;
using UnityEngine.UI;

namespace Office.Scripts {
    /// <inheritdoc />
    /// <summary>
    /// Shows a notification on screen with custom text passed to the component.
    /// </summary>
    public class NotificationCanvas : MonoBehaviour {
        private static string _pendingNotification = string.Empty;
        private const int FadeoutTime = 3;
        private DateTime _disableAt;

        /// <summary>
        /// Create a notification from a given text,
        /// this will fade out after 3 seconds.
        /// </summary>
        /// <param name="text">The notification text.</param>
        public void Notify(string text) {
            this.GetComponentInChildren<Text>().text = text;
            this._disableAt = DateTime.UtcNow.AddSeconds(FadeoutTime);
            this.gameObject.SetActive(true);
        }

        /// <summary>
        /// Create a delayed notification for the next instanced
        /// notification component (e.g.: to reload a scene).
        /// </summary>
        /// <param name="text">The notification text.</param>
        public void CreatePendingNotification(string text) {
            _pendingNotification = text;
        }

        /// <summary>
        /// When starting up the component, if there is a pending notification, handle it.
        /// If there isn't, hide the notification as there is nothing to show.
        /// </summary>
        private void Start() {
            if (_pendingNotification.Length > 0) {
                this.Notify(_pendingNotification);
                _pendingNotification = string.Empty;
            }
            else {
                this.gameObject.SetActive(false);
            }
        }

        /// <summary>
        /// Hides a notification if it timed-out, otherwise, do nothing.
        /// </summary>
        private void Update() {
            if (DateTime.UtcNow <= this._disableAt) {
                return;
            }

            this._disableAt = DateTime.MaxValue;
            this.gameObject.SetActive(false);
        }
    }
}
