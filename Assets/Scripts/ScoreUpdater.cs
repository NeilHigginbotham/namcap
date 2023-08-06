using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUpdater : MonoBehaviour
{
    public Text scoreText;
    public HighScoreManager highScoreManager;

    // Call this function to update the high score
    public void UpdateHighScore()
    {
        string playerName = "PlayerName"; // Replace with the actual player's name or logic to get the player's name.
        int score;

        // Parse the score from the Text component
        if (int.TryParse(scoreText.text, out score))
        {
            // Call the HighScoreManager to save the high score
            highScoreManager.SaveHighScore(playerName, score);
        }
        else
        {
            Debug.LogWarning("Invalid score value in the Text component.");
        }
    }
}