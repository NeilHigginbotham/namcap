using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScoreManager : MonoBehaviour
{
    // This function is called when the player achieves a new high score
    public void SaveHighScore(string playerName, int score)
    {
        // Create a unique key for the player using their name
        string key = "HighScore_" + playerName;

        // Check if the current score is higher than the saved high score
        if (score > PlayerPrefs.GetInt(key, 0))
        {
            // If it's higher, save the new high score
            PlayerPrefs.SetInt(key, score);
            PlayerPrefs.Save();
        }
    }
}

public class HighScoreManagerPersistent : MonoBehaviour
{
    // Singleton instance of the HighScoreManagerPersistent class
    public static HighScoreManagerPersistent Instance { get; private set; }

    // Reference to the HighScoreManager script
    public HighScoreManager highScoreManager;

    private void Awake()
    {
        // Singleton pattern to ensure only one instance exists
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}