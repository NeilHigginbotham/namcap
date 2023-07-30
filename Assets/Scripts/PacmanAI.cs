using System.Collections;
using System.Collections.Generic;
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
        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet)
            agent.SetDestination(walkPoint);

        Vector2 distanceToWalkPoint = transform.position - (Vector3)walkPoint;

        //Walkpoint reached
        if (distanceToWalkPoint.magnitude < 1f)
            walkPointSet = false;

    }
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
    }


    private void AttackGhost()
    {
        agent.SetDestination(ghost1.position);
    }
}
