using UnityEngine;

public class Win : MonoBehaviour
{
    private const string LoseGame = "You Win\nPress to play again";
    private const int ButtonWidth = 200;
    private const int ButtonHeight = 50;

    void OnGUI()
    {
        if (GUI.Button(new Rect((Screen.width / 2) - (ButtonWidth / 2),
            (Screen.height / 2) - (ButtonHeight / 2),
            ButtonWidth, ButtonHeight), LoseGame))
        {
            ResetPlayer();
            Application.LoadLevel(1);
        }
    }

    void ResetPlayer()
    {
        Player.Score = 0;
        Player.Lives = 3;
        Player.Missed = 0;
    }    
}
