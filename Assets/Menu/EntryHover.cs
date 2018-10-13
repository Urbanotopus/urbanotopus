using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Menu {
    public class EntryHover : MonoBehaviour {
        public Color HoverColor = Color.yellow;

        private AudioSource _audioHoverSource;
        private Renderer _renderer = new Renderer();
        private Color _inactiveColor = Color.gray;
        private bool _isHovering;

        private void Start() {
            this._audioHoverSource = this.GetComponent<AudioSource>();
            this._renderer = this.GetComponent<Renderer>();
            Cursor.visible = true;
        }

        private void OnMouseEnter() {
            // we need to ensure this is not being
            // called multiple times during an update
            if (this._isHovering) {
                return;
            }

            this._inactiveColor = this._renderer.material.color;
            this._renderer.material.color = this.HoverColor;
            this._isHovering = true;
            this._audioHoverSource.Play();
        }

        private void OnMouseExit() {
            if (!this._isHovering) {
                return;
            }

            this._renderer.material.color = this._inactiveColor;
            this._isHovering = false;
        }

        private void Update() {
        }
    }
}
