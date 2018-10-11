using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollowAI : MonoBehaviour {

    public float move_speed;

    private Transform target;

    public float stop_distance;

    

    private float player_distance;

    public float chase_range;

    // Use this for initialization
    void Start () {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();


	}
	
	// Update is called once per frame
	void Update () {



        player_distance = Vector3.Distance(target.position, transform.position);

        if (player_distance < chase_range)
        {

            if (Vector2.Distance(transform.position, target.position) > stop_distance)
            {

                transform.position = Vector2.MoveTowards(transform.position, target.position, move_speed * Time.deltaTime);

            }
        }
	}

    
}
