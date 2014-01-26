public enum GameState
{
    StartScreen,
    RunningLava,
    RunningIce,
    GameOver,
    GameWin,
    Pause,
    Credits
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
