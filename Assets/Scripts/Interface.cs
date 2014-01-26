using UnityEngine;

[ExecuteInEditMode]
public class Interface : MonoBehaviour
{

    private Texture _startScreen;
    private Texture _pauseScreen;
    private Texture _creditsScreen;
    private Texture _keyIcon;
    private Rect _topButtonRect;
    private Rect _bottomButtonRect;
    private Rect _fullScreenRect;
    private Rect _keyRect;

	// Use this for initialization
	void Start ()
	{
	    _startScreen = Resources.Load<Texture>("StartScreen");
        _pauseScreen = Resources.Load<Texture>("PauseScreen");
        _creditsScreen = Resources.Load<Texture>("CreditsScreen");
	    _keyIcon = Resources.Load<Texture>("KeyIcon");
	}
	
	// Update is called once per frame
	void Update ()
	{
        //F... constants!
	    float scaleX = Screen.width / 4200f;
	    float scaleY = Screen.height / 2363f;

        _topButtonRect.x = (4200f / 2f - 1094f / 2f) * scaleX;
        _topButtonRect.y = 1124 * scaleY;
        _topButtonRect.width = 1094 * scaleX;
        _topButtonRect.height = 411 * scaleY;

	    _bottomButtonRect = _topButtonRect;
        _bottomButtonRect.y = 1589 * scaleY;

	    _fullScreenRect.x = 0;
	    _fullScreenRect.y = 0;
	    _fullScreenRect.width = Screen.width;
	    _fullScreenRect.height = Screen.height;

        _keyRect = new Rect(20,20,100,100);
	}

    void OnGUI()
    {
        if (GameStateHandler.CurrentGameState == (int) GameState.StartScreen)
        {
            GUI.backgroundColor = Color.clear;
            GUI.DrawTexture(_fullScreenRect, _startScreen, ScaleMode.StretchToFill);
            if (GUI.Button(_topButtonRect, ""))
            {
                GameStateHandler.CurrentGameState = (int) GameState.RunningLava;
                Application.LoadLevel(1);
            }
            if (GUI.Button(_bottomButtonRect, ""))
            {
                Application.Quit();
            }
        }
        else if (GameStateHandler.CurrentGameState == (int)GameState.RunningLava)
        {
        }
        else if (GameStateHandler.CurrentGameState == (int)GameState.RunningIce)
        {

        }
        else if (GameStateHandler.CurrentGameState == (int) GameState.RunningKey)
        {
            GUI.DrawTexture(_keyRect, _keyIcon);
        }
        else if (GameStateHandler.CurrentGameState == (int)GameState.GameWin)
        {
            Application.LoadLevel(0);
            GameStateHandler.CurrentGameState = (int)GameState.Credits;
        }
        else if (GameStateHandler.CurrentGameState == (int)GameState.GameOver)
        {
            Application.LoadLevel(0);
            GameStateHandler.CurrentGameState = (int) GameState.Credits;
        }
        else if (GameStateHandler.CurrentGameState == (int)GameState.Pause)
        {
            GUI.DrawTexture(_fullScreenRect, _pauseScreen, ScaleMode.StretchToFill);
        }
        else if (GameStateHandler.CurrentGameState == (int)GameState.Credits)
        {
            GUI.DrawTexture(_fullScreenRect, _creditsScreen, ScaleMode.StretchToFill);
            if (GUI.Button(_fullScreenRect, ""))
            {
                GameStateHandler.CurrentGameState = (int)GameState.StartScreen;
            }

        }
    }
}
