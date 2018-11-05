﻿using UnityEngine;

namespace Components {
    public class EntryHover : MonoBehaviour {
        public Color HoverColor = Color.yellow;
        public Color DisabledColor = new Color(0.49f, 0.49f, 0.49f);

        private AudioSource _audioHoverSource;
        private Renderer _renderer = new Renderer();
        private Color _inactiveColor = Color.gray;
        private bool _isHovering;
        protected bool IsEnabled = true;

        protected virtual void OnClick() {}

        private void OnMouseUp() {
            if (!this._isHovering) {
                return;
            }
            this.OnClick();
        }

        protected void Start() {
            this._audioHoverSource = this.GetComponent<AudioSource>();
            this._renderer = this.GetComponent<Renderer>();
            Cursor.visible = true;

            if (!this.IsEnabled) {
                this._renderer.material.color = this.DisabledColor;
            }
        }

        protected void ActivateHover() {
            this._inactiveColor = this._renderer.material.color;
            this._renderer.material.color = this.HoverColor;
        }

        protected void DeactivateHover() {
            this._renderer.material.color = this._inactiveColor;
        }

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

        private void OnMouseExit() {
            if (!this._isHovering) {
                return;
            }

            this.DeactivateHover();
            this._isHovering = false;
        }
    }
}
