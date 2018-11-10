using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using Yarn.Unity;

namespace Managers {
    /// <inheritdoc />
    /// <summary>
    /// Manages a Visual Novel scene that is expecting to be given a yarn script to execute.
    /// </summary>
    public class YarnSceneManager : MonoBehaviour {
        /// <summary>
        /// The Yarn script text asset to load into the visual novel scene.
        /// </summary>
        public static TextAsset CurrentYarnScript = null;

        /// <summary>
        /// Loads a given Yarn script that is set on <see cref="CurrentYarnScript" />
        /// and start the scene.
        /// </summary>
        ///
        /// <exception cref="NullReferenceException">
        /// Occurs there is no dialog runner available or
        /// if the target yarn script is not set.
        /// </exception>
        private void Start() {
            // Look for a game object capable of running a Yarn script
            var dialogueRunner = FindObjectOfType<DialogueRunner>();

            // Ensure we found a game object capable of loading a Yarn script
            if (dialogueRunner == null) {
                throw new NullReferenceException("Cannot find a dialog runner.");
            }

            // Ensure there is a script to load, to prevent future issues
            if (CurrentYarnScript == null) {
                throw new NullReferenceException("The yarn script is not set.");
            }

            // Set the dialogue to the given Yarn script resource and start the dialogue
            dialogueRunner.AddScript(CurrentYarnScript.text, CurrentYarnScript.name);
            dialogueRunner.StartDialogue();
        }

        /// <summary>
        /// Whenever the user hit 'cancel',
        /// it gets redirected to the office scene.
        /// </summary>
        private void Update() {
            if (Input.GetButtonUp("Cancel")) {
                SceneManager.LoadScene(InternalScenesManager.Office);
            }
        }
    }
}
