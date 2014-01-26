using UnityEditor;
using UnityEngine;

[ExecuteInEditMode]
public class Interface : MonoBehaviour
{

    private Texture _startScreen;
    private Texture _pauseScreen;
    private Rect _topButtonRect;
    private Rect _bottomButtonRect;

	// Use this for initialization
	void Start ()
	{
	    _startScreen = Resources.Load<Texture>("StartScreen");
	    //_pauseScreen = Resources.Load<Texture>();
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
    }

    void OnGUI()
    {
        if (GameStateHandler.CurrentGameState == (int) GameState.StartScreen)
        {
            GUI.DrawTexture(new Rect(0,0,Screen.width,Screen.height), _startScreen,ScaleMode.StretchToFill);
            GUI.Button(_topButtonRect, "Bla");
        }
        else if (GameStateHandler.CurrentGameState == (int)GameState.Running)
        {

        }
        else if (GameStateHandler.CurrentGameState == (int)GameState.GameWin)
        {

        }
        else if (GameStateHandler.CurrentGameState == (int)GameState.GameOver)
        {

        }
        else if (GameStateHandler.CurrentGameState == (int)GameState.Pause)
        {
           // GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), _pauseScreen, ScaleMode.ScaleToFit);
        }
    }
}
