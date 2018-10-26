using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooterAI : MonoBehaviour {

    public float speed;
    public float stopDistance;
    public float retreatDistance;

    private Transform playerPos;

    private float timeBtwShots;
    public float startTimeBtwShots;

    public GameObject projectile;

    private float waitTime;
    public float startWaitTime;

    private Vector2 moveSpot;
    public float chaseRange; 

    // these variables are used to determine the enemy's patrol range
    private float minX;
    private float maxX;
    private float minY;
    private float maxY;

	// Use this for initialization
	void Start ()
    {
        // get and store a reference to the player object's transform component
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;

        timeBtwShots = startTimeBtwShots;

        waitTime = startWaitTime;

        // enemy range is 10 feet from wherever it is spawned at
        minX = transform.position.x - 10f;
        maxX = transform.position.x + 10f;
        minY = transform.position.y - 10f;
        maxY = transform.position.y + 10f;

        // random spot for enemy to move to
        moveSpot = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));

    }
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        // if player is close enough to enemy, the enemy will begin to chase
        if (Vector2.Distance(transform.position, playerPos.position) < chaseRange )
        {
            KillMode();
        }
        // otherwise enemy will continue to patrol
        else
        {
            PatrolMode();
        }
	}

    void PatrolMode()
    {
        // enemy will move to its random patrol spot
        transform.position = Vector2.MoveTowards(transform.position, moveSpot, speed * Time.deltaTime);

        // enemy has reached random patrol spot
        if (Vector2.Distance(transform.position, moveSpot) < 0.2f)
        {
            // if enemy has waited long enough, assign a new random patrol spot and reset wait time
            if (waitTime <= 0)
            {
                moveSpot = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
                waitTime = startWaitTime;
            }
            // otherwise decrement wait time
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
    }

    void KillMode()
    {
        // if enemy is not within player's stop distance then the enemy will follow player
        if (Vector2.Distance(transform.position, playerPos.position) > stopDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, playerPos.position, speed * Time.deltaTime);
        }

        // if enemy is close enought to player(stop distance) but not too close(retreat distance), enemy will stay at current position 
        else if (Vector2.Distance(transform.position, playerPos.position) < stopDistance && Vector2.Distance(transform.position, playerPos.position) > retreatDistance)
        {
            transform.position = this.transform.position;
        }

        // if enemy is too close to player, the enemy will retreat 
        else if (Vector2.Distance(transform.position, playerPos.position) < retreatDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, playerPos.position, -speed * Time.deltaTime);
        }

        // if time between shots is 0, enemy can shoot a projectile
        if (timeBtwShots <= 0)
        {
            // this will spawn the projectile
            Instantiate(projectile, transform.position, Quaternion.identity);

            // reset counter for time between shots
            timeBtwShots = startTimeBtwShots;
        }
        // othewrise decrease time between shots by 1 eachs second
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }
}
