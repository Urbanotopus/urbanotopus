using System;
using UnityEngine;
using Yarn.Unity;

namespace Managers {
    public class YarnSceneManager : MonoBehaviour {
        public static TextAsset CurrentYarnScript = null;

        private void Start() {
            var dialogueRunner = FindObjectOfType<DialogueRunner>();

            if (dialogueRunner == null) {
                throw new NullReferenceException("Cannot find a dialog runner.");
            }

            if (CurrentYarnScript == null) {
                throw new NullReferenceException("The yarn script is not set.");
            }

            dialogueRunner.sourceText = new []{CurrentYarnScript};
            dialogueRunner.StartDialogue();
        }
    }
}
