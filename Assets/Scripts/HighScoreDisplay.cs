using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreDisplay : MonoBehaviour
{
    public TextMeshProUGUI highScoreText;

    // This function is called when you want to display the high score for a player

    private void Awake()
    {
        // Call the function to display the high score as soon as the scene loads
        DisplayHighScore("PlayerName"); // Replace "PlayerName" with the actual player's name
    }
    public void DisplayHighScore(string playerName)
    {
        // Key for the player using their name
        string key = "HighScore_" + playerName;

        // Get the high score for the player from PlayerPrefs
        int highScore = PlayerPrefs.GetInt(key, 0);

        // Display the high score in the UI
        // not using right now because then i have to make another menu
        // highScoreText.text = "High Score for " + playerName + ": " + highScore.ToString();
        highScoreText.text = "High Score " + ": " + highScore.ToString();
    }
}