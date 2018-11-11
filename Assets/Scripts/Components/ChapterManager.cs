using Managers;
using UnityEngine;
using UnityEngine.UI;

namespace Components {
    /// <summary>
    /// A simple description of what is chapter (a name, and a yarn script)
    /// </summary>
    [System.Serializable]
    public class Chapter {
        /// <summary>
        /// The name of this chapter.
        /// </summary>
        public string Name;

        /// <summary>
        /// The yarn script asset of this chapter.
        /// </summary>
        public TextAsset YarnAsset;

        /// <summary>
        /// Converts a <see cref="Chapter"/> to a string.
        /// </summary>
        /// <returns>The name of the chapter.</returns>
        public override string ToString() {
            return this.Name;
        }
    }

    /// <inheritdoc />
    /// <summary>
    /// A game object component that manages given chapters.
    /// It will take a panel to populate with a given prefab <see cref="UIChapterEntryPrefab"/>.
    /// </summary>
    public class ChapterManager : MonoBehaviour {
        /// <summary>
        /// The list of chapters to render.
        /// </summary>
        public Chapter[] ListOfChapters;

        /// <summary>
        /// The container panel that will get populated by the instanced chapter prefabs.
        /// </summary>
        public RectTransform ContainerContentPanel;

        /// <summary>
        /// A prefab to multiply and populate over the gaven panel.
        /// This prefab, must contain:
        /// <list type="bullet">
        ///     <item>A button component (at the root);</item>
        ///     <item>A image component (at the root);</item>
        ///     <item>A text game object (as child).</item>
        /// </list>
        /// </summary>
        public GameObject UIChapterEntryPrefab;  // noqa

        /// <summary>
        /// The background color of an uncompleted's chapter button.
        /// </summary>
        public Color UnCompletedColor = new Color(0.3f, 0.3f, 0.3f, 0.5f);

        /// <summary>
        /// The text color of an uncompleted chapter's button.
        /// </summary>
        public Color UnCompletedTextColor = Color.black;

        /// <summary>
        /// The background color of a completed chapter's button.
        /// </summary>
        public Color CompletedColor = new Color(0.5f, 0.5f, 0.5f, 0.1f);

        /// <summary>
        /// The text color of a completed chapter button.
        /// </summary>
        public Color CompletedTextColor = Color.black;

        /// <summary>
        /// This will, on a given <seealso cref="Chapter">chapter</seealso>:
        /// <list type="bullet">
        ///     <item>Instance a given prefab and set it to be the parent of the given panel.</item>
        ///     <item>Set the text and background color depending on if the chapter has been completed or not.</item>
        ///     <item>Register a listener that will load the yarn asset whenever the user clicks on the button.</item>
        /// </list>
        /// </summary>
        /// <param name="id">The said position of this chapter;</param>
        /// <param name="chapter">The chapter object;</param>
        /// <param name="isCompleted">Was the chapter completed or not.</param>
        private void AddChapter(int id, Chapter chapter, bool isCompleted) {
            var newChapterEntry = Instantiate(this.UIChapterEntryPrefab);
            var image = newChapterEntry.GetComponent<Image>();
            var button = newChapterEntry.GetComponent<Button>();
            var text = newChapterEntry.GetComponentInChildren<Text>();

            // Set the parent of the chapter game object to be the content panel.
            newChapterEntry.transform.SetParent(this.ContainerContentPanel);

            // Set the button text to be: `<chapter_id>: <chapter_name>`.
            text.text = string.Format("{0}: {1}", id, chapter);

            // Set the background and text color with the given ones.
            // ...Here is for a completed chapter.
            if (isCompleted) {
                image.color = this.CompletedColor;
                text.color = this.CompletedTextColor;
            }
            // Set the colors of a non-completed chapter.
            else {
                image.color = this.UnCompletedColor;
                text.color = this.UnCompletedTextColor;
            }

            // Register a 'on click' event to the button,
            // that will load the yarn script whenever the user clicks on the button.
            button.onClick.AddListener(() => {
                YarnSceneManager.LoadYarn(chapter.YarnAsset);
            });
        }

        /// <summary>
        /// When the component awakes, it populates the container panel with given chapters.
        /// </summary>
        private void Awake() {
            // The (said) starting point ID, we are guessing data is ordered.
            var id = 1;

            // Retrieve the saved played chapters.
            var playedChapters = SaveGameManager.GetCurrentGame().PlayedChapters;

            // Note that the previous chapter was not completed
            // if there are completed chapters.
            // That will allow us to hide every chapter after the next one to be completed.
            var previousWasCompleted = playedChapters.Count < 1;

            // Populate the container panel with chapters
            foreach (var chapter in this.ListOfChapters) {
                // Flag the chapter as completed if it is in the list of completed chapters.
                var isCompleted = playedChapters.Contains(chapter.YarnAsset.name);

                // Add the chapter on the container panel
                this.AddChapter(id++, chapter, isCompleted);

                // If the previous chapter was completed and the current one wasn't,
                // don't show the next chapters.
                if (previousWasCompleted && !isCompleted) {
                    break;
                }

                // If the chapter was completed, flag that the previous chapter (this one) was completed.
                if (isCompleted) {
                    previousWasCompleted = true;
                }
            }
        }
    }
}
