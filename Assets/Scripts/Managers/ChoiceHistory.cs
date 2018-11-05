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
        private Dictionary<int, TChapterChoices> _chapterChoices =
            new Dictionary<int, TChapterChoices>();

        /// <summary>
        /// Registers taken choices to a serializable chapter history.
        /// </summary>
        /// <param name="chapterId">The current chapter ID.</param>
        /// <param name="questionId">The current question ID.</param>
        /// <param name="answerId">The chosen answer ID.</param>
        public void RegisterChoice(int chapterId, int questionId, int answerId) {
            TChapterChoices choices;

            // if the chapter is already registered, just retrieve it
            if (this._chapterChoices.ContainsKey(chapterId)) {
                choices = this._chapterChoices[chapterId];
            }
            else {
                // if the chapter is yet to be registered,
                // create its storage
                choices = new TChapterChoices();
                this._chapterChoices[chapterId] = choices;
            }

            // register the answer
            choices[questionId] = answerId;
        }

        /// <summary>
        /// Represents a choice history object to a string object.
        /// </summary>
        /// <returns></returns>
        public override string ToString() {
            var result = string.Empty;

            foreach (var chapter in this._chapterChoices) {
                var formattedQuestion = string.Empty;
                foreach (var question in chapter.Value) {
                    formattedQuestion += string.Format("[{0}, {1}], ", question.Key, question.Value);
                }
                result += string.Format("Chapter #{0}: {1}", chapter.Key, formattedQuestion);
            }

            return result;
        }
    }
}
