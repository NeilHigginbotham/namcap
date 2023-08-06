using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class YourScoreChangeLogic : MonoBehaviour
{
    public Text scoreText;
    public ScoreUpdater scoreUpdater; 

    // Example function to update the score and save it as the high score
    public void UpdateScoreAndSaveHighScore(int newScore)
    {
        // Update the score in the Text component
        scoreText.text = newScore.ToString();

        // Save the high score using the ScoreUpdater script
        scoreUpdater.UpdateHighScore();
    }
}