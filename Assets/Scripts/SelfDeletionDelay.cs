using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDeletionDelay : MonoBehaviour
{
    // Time in seconds before the text object gets destroyed
    public float destroyDelay = 3.5f;

    private void Start()
    {
        // Destroy the text object after the specified delay
        StartCoroutine(DestroyAfterDelay());
    }

    private IEnumerator DestroyAfterDelay()
    {
        // Wait for the specified delay
        yield return new WaitForSeconds(destroyDelay);

        // Destroy text object
        Destroy(gameObject);
    }
}