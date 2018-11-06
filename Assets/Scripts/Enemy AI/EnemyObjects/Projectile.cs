using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    public float speed;

    private Transform playerPos;
    private Vector2 target;
    public float timeActive = 5;

    void Start()
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
        target = new Vector2(playerPos.position.x, playerPos.position.y);
    }

    void Update()
    {
        // projectile will home in on the player
        //transform.position = Vector2.MoveTowards(transform.position, playerPos.position, speed * Time.deltaTime);

        // projectile will go to player's last position
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);

        // projectile will disappear when it reachers player's last position
        if (Vector2.Distance(transform.position, target) == 0f)
        {
            DestroyProjectile();
        }

        // projectile will disappear after a set amount of time
        //if (timeActive <= 0)
        //{
        //    DestroyProjectile();
        //}
        //// otherwise decrement timeActive
        //else
        //{
        //    timeActive -= Time.deltaTime;
        //}
    }

    // projectile disappers if it comes to contact with player 
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            DestroyProjectile(); 
        }
    }

    // destroys projectile game object
    void DestroyProjectile()
    {
        Destroy(gameObject); 
    }

}
