using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.SceneManagement;

public class GhostInteraction : MonoBehaviour
{
    // Determines whether the ghost or pacman will die on collision.
    public bool PoweredUp;

    void Start()
    {
        PoweredUp = false;
    }


    // If the powerup has not been recently picked up, the ghost will destroy pacman.
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Pacman") && (PoweredUp == false))
        {
            Destroy(collision.gameObject);
            PacmanBeaten();
        }
    }
    public void PacmanBeaten()
    {
        // Once the enemy is destroyed, call the SaveHighScore function from the HighScoreManager

        string playerName = "PlayerName"; // Replace this with the actual player's name

        int score = 100; // Replace this with the actual score achieved by the player

        HighScoreManager highscoreManager = GameObject.Find("HighScoreManager").GetComponent<HighScoreManager>();
        highscoreManager.SaveHighScore(playerName, score);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}