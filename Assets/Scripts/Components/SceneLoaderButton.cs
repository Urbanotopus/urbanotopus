using System;
using Managers;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Components {
    public class SceneLoaderButton : MonoBehaviour {
        private const string _YARN_SCENE_LOADER = "VisualNovelScene";
        public TextAsset YarnSceneToLoad;

        private void Start() {
            if (this.YarnSceneToLoad == null) {
                throw new NullReferenceException("The Yarn script is not referenced.");
            }
            this.GetComponentInParent<Button>().onClick.AddListener(() => OnClick());
        }

        private void OnClick() {
            YarnSceneManager.CurrentYarnScript = YarnSceneToLoad;
            SceneManager.LoadScene(_YARN_SCENE_LOADER);
        }
    }
}
