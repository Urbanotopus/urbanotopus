using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GlobalBackgroundGameManager : MonoBehaviour {
    public SceneAsset DebugScene;
    private static bool _created;

    private void Awake() {
        if (!_created) {
            DontDestroyOnLoad(this.gameObject);
            _created = true;
        }
        else {
            Destroy(this.gameObject);
        }
    }

    private void FixedUpdate() {
        if (Input.GetKey (KeyCode.F12)) {
            SceneManager.LoadScene(this.DebugScene.name);
        }
    }
}
