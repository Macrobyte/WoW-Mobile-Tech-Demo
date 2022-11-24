using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{


    [Header("Patrolling Settings")]
    public GameObject patrolArea;
    [SerializeField] private float speed;
    private Vector2 waypoint;

    
    private void Start()
    {
        waypoint = GetNewWaypoint(patrolArea.GetComponent<Collider2D>().bounds);
    }

    private void Update()
    {
        HandlePatrolling();
    }


    


    #region Patrolling
    private void HandlePatrolling()
    {
        transform.position = Vector2.MoveTowards(transform.position, waypoint, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, waypoint) < 0.2f)
        {
            waypoint = GetNewWaypoint(patrolArea.GetComponent<Collider2D>().bounds);
        }
    }

    private Vector2 GetNewWaypoint(Bounds bounds)
    {
       return new Vector2(Random.Range(bounds.min.x, bounds.max.x), Random.Range(bounds.min.y, bounds.max.y));
    }

    #endregion



}
