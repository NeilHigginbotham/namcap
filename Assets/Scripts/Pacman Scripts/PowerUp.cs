using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline.Actions;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public bool PoweredUp;
    public float powerUpDuration = 5f;
    private GhostInteraction ghost;
    private ScoreUpdate powerUp;


    private void Start()
    {
        ghost = FindObjectOfType<GhostInteraction>();
        powerUp = FindObjectOfType<ScoreUpdate>();
    }

    // After the pacman touches the power up, they gain the temporary ability to destroy the ghost.
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            ApplyPowerUpEffect(other.gameObject);
            StartCoroutine(RemovePowerUpEffectAfterDelay(other.gameObject));
            ghost.PoweredUp = true;
            powerUp.PoweredUp = true;
            Debug.Log("powerup grabbed");
        } 
    }

    private void ApplyPowerUpEffect(GameObject player)
    {
        PoweredUp = true;
    }

    private IEnumerator RemovePowerUpEffectAfterDelay(GameObject player)
    {
        yield return new WaitForSeconds(powerUpDuration);
        PoweredUp = false;
        ghost.PoweredUp = false;
        powerUp.PoweredUp = false;
        Destroy(gameObject);
    }
}
