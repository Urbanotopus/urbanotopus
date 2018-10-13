using Boo.Lang;
using UnityEngine;

namespace Managers {
    public class SaveGameManager : MonoBehaviour {
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

        public static SaveGameManager GetGameManager() {
            return FindObjectOfType<SaveGameManager>();
        }

        public List<int> ListSaves() {
            // FIXME: implement me (see #9)
            return new List<int>();
        }
    }
}
