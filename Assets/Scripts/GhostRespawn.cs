using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class GhostRespawn : MonoBehaviour
{
    public GameObject ghost1;
    public GameObject Eyes;
    public GameObject Ghostspawn;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Junk Remover"))
        {
            Debug.Log("eye and respawn collision");
            Destroy(gameObject);
            Instantiate(ghost1, Ghostspawn.transform.position, Quaternion.identity);
            Debug.Log("eyes at spawn");
        }
    }
}
