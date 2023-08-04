using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class PelletRemoval : MonoBehaviour
{
    public GameObject ghost1;
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Eyes"))
        {
            Destroy(collision.gameObject);
            Instantiate(ghost1, transform.position, Quaternion.identity);
            Debug.Log("eyes at spawn");
        }
    }
}
