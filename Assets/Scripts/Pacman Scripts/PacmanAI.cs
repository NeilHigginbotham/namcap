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
    // The bool below is not used anymore but essential for many previous iterations so it will stay.
    //bool walkPointSet;
    public float walkPointRange;

    public Transform ghost1;




    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    // This method tracks the new ghost if pacman happens to destroy it. Acesses script from GhostRespawn.cs
    public void SetCurrentGhost(Transform ghost)
    {
        ghost1 = ghost;
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
        Collider2D[] nearbyPellets = Physics2D.OverlapCircleAll(transform.position, sightRange, Pellet);

        // Check if there are any pellets nearby
        if (nearbyPellets.Length > 0)
        {
            float closestDistance = Mathf.Infinity;
            Vector2 closestPelletPosition = Vector2.zero;

            // Find the closest pellet among the nearby pellets
            foreach (Collider2D pellet in nearbyPellets)
            {
                float distanceToPellet = Vector2.Distance(transform.position, pellet.transform.position);
                if (distanceToPellet < closestDistance)
                {
                    closestDistance = distanceToPellet;
                    closestPelletPosition = pellet.transform.position;
                }
            }

            // Set the walkPoint to the position of the closest pellet
            //walkPointSet = true;
            walkPoint = closestPelletPosition;
            agent.SetDestination(walkPoint);
        }
    }

    private void AttackGhost()
    {
        // Check if the ghost is in attack range
        if (ghostInAttackRange)
        {
        // Set the walkPoint to a position that moves away from the ghost
        Vector2 directionToGhost = transform.position - ghost1.position;
        walkPoint = (Vector2)transform.position + directionToGhost.normalized * walkPointRange;

        agent.SetDestination(walkPoint);
        }
    }
}

//Old code below I want to preserve just in case.

/*else
       {
           // No pellets nearby, continue searching for a random walkPoint
           if (!walkPointSet)
           {
               Searching();
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
           {
               Debug.DrawLine(transform.position, walkPoint, UnityEngine.Color.blue);
               agent.SetDestination(walkPoint);
           }
       }*/

// Below is old code that was a struggle to make work. Above method is functional but includes useless code at and below the else statement.
/*
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

        if (distanceToWalkPoint.magnitude < 5f)
        {
            walkPointSet = false;
        }
    }

    if (walkPointSet)
    {
        Debug.DrawLine(transform.position, walkPoint, UnityEngine.Color.blue);
        agent.SetDestination(walkPoint);
    }


} */
/*
private void SearchWalkPoint()
{
    Vector2 randomPoint;

    int attempts = 0;
    int maxAttempts = 200;


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
    // set it to a fallback random point within the walkPointRange.
    randomPoint = new Vector2(transform.position.x + Random.Range(-walkPointRange, walkPointRange),
                              transform.position.y + Random.Range(-walkPointRange, walkPointRange));
    }


    walkPointSet = true;
    walkPoint = randomPoint;
}

private bool IsPointWithinNavMesh(Vector2 point)
{
    NavMeshHit hit;
    Debug.Log("navmeshbool check");

    // Checks around the brand new randomPoint creatured in the do method. If area is found to be in the Navmesh, we should set the bool to true.
    return NavMesh.SamplePosition(point, out hit, 1f, NavMesh.AllAreas);
} */



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

// Below code was intended to make movement cardinal for pacman but was not functional
/*else
{
    // No pellets nearby, continue searching for a random walkPoint
    if (walkPointSet)
    {
        Vector2 currentPos = new Vector2(transform.position.x, transform.position.y);
        Vector2 distanceToWalkPoint = currentPos - walkPoint;

        if (distanceToWalkPoint.magnitude < 1f)
        {
            walkPointSet = false;
        }
    }

    if (walkPointSet)
    {
        Debug.DrawLine(transform.position, walkPoint, UnityEngine.Color.blue);
        agent.SetDestination(walkPoint);
    }
} */