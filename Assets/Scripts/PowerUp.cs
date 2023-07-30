using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline.Actions;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public bool PoweredUp;
    public float powerUpDuration = 5f;

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log ("powerup touched");
            ApplyPowerUpEffect(other.gameObject);
            StartCoroutine(RemovePowerUpEffectAfterDelay(other.gameObject));
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
    }
}
