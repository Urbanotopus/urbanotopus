using Managers;
using UnityEngine;
using UnityEngine.UI;

namespace Components {
    [System.Serializable]
    public class Chapter {
        public string Name;
        public TextAsset YarnAsset;

        public override string ToString() {
            return this.Name;
        }
    }

    public class ChapterManager : MonoBehaviour {
        public Chapter[] ListOfChapters;
        public GameObject UIChapterEntryPrefab;
        public RectTransform ContainerContentPanel;

        public Color UnCompletedColor = new Color(0.3f, 0.3f, 0.3f, 0.5f);
        public Color UnCompletedTextColor = Color.black;

        public Color CompletedColor = new Color(0.5f, 0.5f, 0.5f, 0.1f);
        public Color CompletedTextColor = Color.black;

        private void AddChapter(int id, Chapter chapter, bool isCompleted) {
            var newChapterEntry = Instantiate(this.UIChapterEntryPrefab);
            var image = newChapterEntry.GetComponent<Image>();
            var text = newChapterEntry.GetComponentInChildren<Text>();
            newChapterEntry.transform.SetParent(this.ContainerContentPanel);

            text.text = string.Format("{0}: {1}", id, chapter);
            if (isCompleted) {
                image.color = this.CompletedColor;
                text.color = this.CompletedTextColor;
            }
            else {
                image.color = this.UnCompletedColor;
                text.color = this.UnCompletedTextColor;
            }
        }

        private void Awake() {
            var id = 1;
            var lastPlayedName = SaveGameManager.GetCurrentGame().LastPlayedChapter;
            var previousWasCompleted = false;

            foreach (var chapter in this.ListOfChapters) {
                var isCompleted = chapter.Name.Equals(lastPlayedName);
                this.AddChapter(id++, chapter, isCompleted);

                if (previousWasCompleted) {
                    break;
                }
                if (isCompleted) {
                    previousWasCompleted = true;
                }
            }
        }
    }
}
