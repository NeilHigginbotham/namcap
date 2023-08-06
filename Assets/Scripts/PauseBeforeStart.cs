using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseBeforeStart : MonoBehaviour
{
    // Adjust this variable to set the pause duration in seconds
    public float pauseDuration = 3.5f;

    private void Start()
    {
        // Start the coroutine to pause the game for a brief moment
        StartCoroutine(PauseGameBeforeLevelStart());
    }

    private IEnumerator PauseGameBeforeLevelStart()
    {
        // Pause the game
        Time.timeScale = 0f;

        // Wait for the specified pause duration
        yield return new WaitForSecondsRealtime(pauseDuration);

        // Resume the game
        Time.timeScale = 1f;
    }
}