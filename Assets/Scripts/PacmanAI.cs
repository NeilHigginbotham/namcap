using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.AI;

public class PacmanAI : MonoBehaviour
{
    //private Vector3 target;
    public NavMeshAgent agent;
    public LayerMask Pellet;
    public LayerMask Ghost;

    public bool ghostInAttackRange, pelletInSightRange;
    public float sightRange;
    public float attackRange;

    public Vector2 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    public Transform ghost1;



    private void Awake()
    {
        ghost1 = GameObject.Find("ghost").transform;
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    // Update is called once per frame
    void Update()
    {
        pelletInSightRange = Physics2D.OverlapCircle(transform.position, sightRange, Pellet);
        ghostInAttackRange = Physics2D.OverlapCircle(transform.position, attackRange, Ghost);

        if (pelletInSightRange && !ghostInAttackRange) Searching();
        if (pelletInSightRange && ghostInAttackRange) AttackGhost();
    }

    private void Searching()
    {
        if (!walkPointSet)
        {
            SearchWalkPoint();
        }
        else
        {
            Vector2 currentPos = new Vector2(transform.position.x, transform.position.y);
            Vector2 distanceToWalkPoint = currentPos - walkPoint;

            if (distanceToWalkPoint.magnitude < 1f)
            {
                walkPointSet = false;
            }
        }

        if (walkPointSet)
            agent.SetDestination(walkPoint);

    }

    private void SearchWalkPoint()
    {
        Vector2 randomPoint;

        int attempts = 0;
        int maxAttempts = 30;

        do
        {
            // Calculate random point in range
            float randomX = Random.Range(-walkPointRange, walkPointRange);
            float randomY = Random.Range(-walkPointRange, walkPointRange);

            randomPoint = new Vector2(transform.position.x + randomX, transform.position.y + randomY);
            attempts++;
        }
        while (!IsPointWithinNavMesh(randomPoint) && attempts < maxAttempts);

        if (attempts >= maxAttempts)
        {
            // If we can't find a valid walk point after several attempts,
            // use the current position as a fallback to avoid getting stuck.
            randomPoint = transform.position;
        }

        walkPointSet = true;
        walkPoint = randomPoint;
    }

    private bool IsPointWithinNavMesh(Vector2 randomPoint)
    {
        NavMeshHit hit;
        return NavMesh.SamplePosition(randomPoint, out hit, 10f, NavMesh.AllAreas);
    }

    private void AttackGhost()
        {
            agent.SetDestination(ghost1.position);
        }
 
}


/*
private void SearchWalkPoint()
{
    //Calculate random point in range
    float randomX = Random.Range(-walkPointRange, walkPointRange);
    float randomY = Random.Range(-walkPointRange, walkPointRange);

    Vector2 randomPoint = new Vector2(transform.position.x + randomX, transform.position.y + randomY);

    NavMeshHit hit;
    if (NavMesh.SamplePosition(randomPoint, out hit, walkPointRange, NavMesh.AllAreas))
    {
        walkPointSet = true;
        walkPoint = hit.position;
    }
} */