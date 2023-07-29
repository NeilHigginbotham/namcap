using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class GhostInteraction : MonoBehaviour
{

    public bool PoweredUp;

    void Start()
    {
        PoweredUp = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Pacman") && (PoweredUp == false))
        {
            Destroy(collision.gameObject);

        }
    }
}
