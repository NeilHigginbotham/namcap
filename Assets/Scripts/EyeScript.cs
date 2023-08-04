using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EyeScript : MonoBehaviour
{

    public NavMeshAgent agent;
    public Vector2 walkPoint;
    public GameObject GhostSpawn;

    // Start is called before the first frame update
    void Start()
    {
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    // Update is called once per frame
    void Update()
    {
        walkPoint = GhostSpawn.transform.position;
        agent.SetDestination(walkPoint);
    }
}
