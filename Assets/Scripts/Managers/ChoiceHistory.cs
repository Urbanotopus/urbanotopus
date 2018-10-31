using System;
using System.Collections.Generic;

namespace Managers {
    [Serializable]
    public class ChoiceHistory {
        private static Dictionary<int, Dictionary<int, int>> _chapterChoices =
            new Dictionary<int, Dictionary<int, int>>();

        public static void RegisterChoice(int chapterId, int questionId, int answerId) {
            Dictionary<int, int> choices;
            if (_chapterChoices.ContainsKey(chapterId)) {
                choices = _chapterChoices[chapterId];
            }
            else {
                choices = new Dictionary<int, int>();
                _chapterChoices[chapterId] = choices;
            }

            choices[questionId] = answerId;
        }
    }
}
