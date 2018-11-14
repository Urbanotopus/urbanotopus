using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Managers {
    /// <summary>
    /// Manages the state of a game, containing all serializable
    /// data possible that needs get saved and restored.
    /// </summary>
    [System.Serializable]
    public class GameState {
        public ChoiceHistory ChoiceHistory = new ChoiceHistory();

        [OptionalField(VersionAdded=2)]
        public float TextSpeed = 0.004f;

        [OptionalField(VersionAdded=2)]
        public HashSet<string> PlayedChapters = new HashSet<string>();
    }
}
