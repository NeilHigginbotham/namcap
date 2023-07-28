using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class ScoreUpdate : MonoBehaviour
{
    public Text scoreText;
    private int score;

    void Start()
    {

        scoreText.text = "";
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
    }


}
