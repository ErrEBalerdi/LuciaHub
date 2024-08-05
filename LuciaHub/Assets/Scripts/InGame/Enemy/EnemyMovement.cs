using Enums;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private EnemyState actualState;
    [SerializeField] private float chaseDistance;
    [SerializeField, ReadOnly] private float distanceToPlayer;
    [SerializeField] private float speed;
    [SerializeField] private float waitTime;
    [SerializeField] private Transform[] waypoints;

    private int currentWaypoint = 0;
    private bool isWaiting = false;
    private Transform player;

    private Rigidbody2D rb;

    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        distanceToPlayer = Mathf.Abs(player.position.x - transform.position.x);

        if (distanceToPlayer < chaseDistance)
            actualState = EnemyState.Chase;
        else if (distanceToPlayer > 1.2 * chaseDistance)
            actualState = EnemyState.Patrol; // EnemyState.Search cuando este hecho
    }

    void FixedUpdate()
    {
        switch ((int)actualState)
        {
            // On Patrolling
            case 0:
                UpdatePatrol();
                break;

            // On Chasing
            case 1:
                MoveTo(player.position);
                break;

            // On Searching
            case 2:
                break;
        }
    }

    private void MoveTo(Vector3 targetPosition)
    {
        Vector2 direction = (targetPosition - transform.position).normalized;

        Vector2 moveDirection = new Vector2(direction.x * speed * Time.fixedDeltaTime, rb.velocity.y);

        rb.velocity = moveDirection;
    }
    private void UpdatePatrol()
    {
        if(Mathf.Round(transform.position.x) != waypoints[currentWaypoint].position.x)
        {
            MoveTo(waypoints[currentWaypoint].position);
        }
        else if(!isWaiting)
        {
            StartCoroutine(Wait());
        }
    }

    IEnumerator Wait()
    {
        isWaiting = true;

        yield return new WaitForSeconds(waitTime);
        currentWaypoint++;

        if(currentWaypoint == waypoints.Length)
            currentWaypoint = 0;

        isWaiting = false;
    }
}
