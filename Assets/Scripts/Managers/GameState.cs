namespace Managers {
    /// <summary>
    /// Manages the state of a game, containing all serializable
    /// data possible that needs get saved and restored.
    /// </summary>
    [System.Serializable]
    public class GameState {
        public ChoiceHistory ChoiceHistory = new ChoiceHistory();
        public float TextSpeed = 0.004f;
        public string LastPlayedChapter = "nil";
    }
}
