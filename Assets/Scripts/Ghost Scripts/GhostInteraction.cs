using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

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

        }
    }
}
