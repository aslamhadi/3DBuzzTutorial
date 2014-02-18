using UnityEngine;

public class MainMenu : MonoBehaviour
{
    private const string InstructionText = "Instruction:\nPress Left and Right arrow to move.\nPress Spacebar to fire";
    private const string StartGame = "Start Game";
    private const int ButtonWidth = 200;
    private const int ButtonHeight = 50;

    void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 250, 200), InstructionText);
        if (GUI.Button(new Rect((Screen.width/2) - (ButtonWidth/2),
            (Screen.height/2) - (ButtonHeight/2),
            ButtonWidth, ButtonHeight), StartGame))
        {
            Application.LoadLevel(1);
        }
    }
}
