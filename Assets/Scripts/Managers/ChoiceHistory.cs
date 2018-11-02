using System;
using System.Collections.Generic;
using TChapterChoices = System.Collections.Generic.Dictionary<int, int>;

namespace Managers {
    [Serializable]
    public class ChoiceHistory {
        /// <summary>
        /// Dictionary storing the list of choices (<code>question_id: answer_id</code>)
        /// per chapter.
        /// </summary>
        private static Dictionary<int, TChapterChoices> _chapterChoices =
            new Dictionary<int, TChapterChoices>();

        /// <summary>
        /// Registers taken choices to a serializable chapter history.
        /// </summary>
        /// <param name="chapterId">The current chapter ID.</param>
        /// <param name="questionId">The current question ID.</param>
        /// <param name="answerId">The chosen answer ID.</param>
        public static void RegisterChoice(int chapterId, int questionId, int answerId) {
            TChapterChoices choices;

            // if the chapter is already registered, just retrieve it
            if (_chapterChoices.ContainsKey(chapterId)) {
                choices = _chapterChoices[chapterId];
            }
            else {
                // if the chapter is yet to be registered,
                // create its storage
                choices = new TChapterChoices();
                _chapterChoices[chapterId] = choices;
            }

            // register the answer
            choices[questionId] = answerId;
        }
    }
}
