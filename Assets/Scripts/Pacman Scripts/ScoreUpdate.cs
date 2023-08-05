using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using UnityEngine.XR;

public class ScoreUpdate : MonoBehaviour
{
    public GameObject eyes;
    public Text scoreText;
    private int score;
    public bool PoweredUp;
    private GhostInteraction ghostInteracton;

    void Start()
    {
        PoweredUp = false;
        scoreText.text = "";
        ghostInteracton = GetComponent<GhostInteraction>();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "" + score;

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Pellet"))
        {
            score -= 10;
            Destroy(collision.gameObject);
            
        }
        if (collision.gameObject.layer == LayerMask.NameToLayer("Power Up"))
        {
            score -= 50;
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.layer == LayerMask.NameToLayer("Ghost") && PoweredUp == true)
        {
            score -= 200;
            Destroy(collision.gameObject);
            Reincarnation();
        }
    }
    //Creates the eye gameobject which will respawn the ghost.
    void Reincarnation()
    {
        Instantiate(eyes, transform.position, Quaternion.identity);
    }
}

