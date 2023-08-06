using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndCredits : MonoBehaviour
{
    float WaitDuration = 20f;

    private void Start()
    {
        // Start the coroutine to pause the game for a brief moment
        StartCoroutine(ExitGame());
    }

    private IEnumerator ExitGame()
    {
        yield return new WaitForSecondsRealtime(WaitDuration);
        Application.Quit();
        Debug.Log("ExitGame Trigggered");
    }
}