using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMovement : MonoBehaviour
{
    private Transform target;
    private int wavepointIndex = 0;
    PlayerStats playerStats;
    [SerializeField] int damage = 1;

    private Enemy enemy;
    [SerializeField] GameObject ObjectToFaceWaypoint;

    private void Start()
    {
        target = Waypoints.waypoints[0];
        playerStats = PlayerStats.playerStats;
        enemy = GetComponent<Enemy>();

    }
    private void Update()
    {
        Vector3 direction = target.position - transform.position;
        transform.Translate(direction.normalized * enemy.speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.2f)
        {
            GetNextWaypoiny();
        }
        if(ObjectToFaceWaypoint!= null)
        {
            ObjectToFaceWaypoint.transform.LookAt(target);
        }

        enemy.speed = enemy.startSpeed;
    }

    private void GetNextWaypoiny()
    {
        //Debug.Log("index = " + wavepointIndex);
        //Debug.Log("Length = " + Waypoints.waypoints.Length);        

        if (wavepointIndex >= Waypoints.waypoints.Length - 1)
        {
            EnnemyReachesEndpoint();
            return;
        }

        wavepointIndex++;
        target = Waypoints.waypoints[wavepointIndex];
    }

    private void EnnemyReachesEndpoint() //update lives and destroy the enemy 
    {
        Destroy(gameObject);
        WaveSpawner.enemiesAlive--;
        playerStats.ReduceHP(damage);
        
    }
}
