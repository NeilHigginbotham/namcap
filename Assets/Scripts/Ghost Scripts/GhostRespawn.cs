using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class GhostRespawn : MonoBehaviour
{

    // There are two ghosts because one is part of the scene initially and the other is a newly spawned prefab.
    public GameObject ghost1;
    public GameObject Eyes;
    public GameObject Ghostspawn;
    public GameObject ghost;

    // After touching the entrance to ghost spawn, the ghost will spawn.
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Junk Remover"))
        {
            Debug.Log("eye and respawn collision");
            Destroy(gameObject);
            Instantiate(ghost1, Ghostspawn.transform.position, Quaternion.identity);


            // This script ensures that the pacmanAI understands that it should be running from the new ghost.
            PacmanAI pacmanAI = GameObject.Find("EnemyPacman").GetComponent<PacmanAI>();
            pacmanAI.SetCurrentGhost(ghost.transform);
            Debug.Log("new ghost set");
        }
    }
}

