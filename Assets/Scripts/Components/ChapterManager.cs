using UnityEngine;

namespace Components {
    [System.Serializable]
    public class Chapter {
        public string Name;
        public TextAsset YarnAsset;

        public override string ToString() {
            return string.Format("{0} at {1}", this.Name, this.YarnAsset);
        }
    }

    public class ChapterManager : MonoBehaviour {
        public Chapter[] ListOfChapters;
    }
}
