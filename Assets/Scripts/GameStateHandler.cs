public enum GameState
{
    StartScreen,
    Running,
    GameOver,
    GameWin,
    Pause
}
public static class GameStateHandler
{

    private static int _currentGameState = (int) GameState.StartScreen;

    public static int CurrentGameState
    {
        get { return _currentGameState; }
        set { _currentGameState = value; }
    }
}
