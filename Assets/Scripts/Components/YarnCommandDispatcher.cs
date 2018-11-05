using Managers;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using Yarn.Unity;

namespace Components {
    public class YarnCommandDispatcher : MonoBehaviour {
        /// <summary>
        /// True if an instance of this game object was created.
        /// Ensuring its uniqueness.
        /// </summary>
        private static bool _created;

        /// <summary>
        /// If it doesn't exist yet, it flags itself as existing
        /// and as not to be destroyed on load (no matter what).
        ///
        /// Otherwise, it flags itself as to be killed (destroyed).
        /// </summary>
        private void Awake() {
            if (!_created) {
                DontDestroyOnLoad(this.gameObject);
                _created = true;
            }
            else {
                Destroy(this.gameObject);
            }
        }

        /// <summary>
        /// Yarn command to registers taken choices to a serializable chapter history.
        /// </summary>
        /// <param name="chapterId">The current Yarn chapter's ID.</param>
        /// <param name="questionId">The current question's ID.</param>
        /// <param name="answerId">The chosen answer's ID.</param>
        [YarnCommand("register_choice")]
        public void RegisterChoice(int chapterId, int questionId, int answerId) {
            SaveGameManager.GetCurrentGame().ChoiceHistory.RegisterChoice(
                chapterId, questionId, answerId);
        }
    }
}
