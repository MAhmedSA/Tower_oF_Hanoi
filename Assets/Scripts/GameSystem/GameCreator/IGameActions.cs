public interface IGameActions
{
    event System.Action<GameState> OnGameStateChanged;
    void ResetGame();
    void AutoSolving();
}
