using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMovement : MonoBehaviour {

    public float move_speed;

    private Rigidbody2D my_rigid_body;

    public bool is_walking;

    public float start_walk_time;
    private float walk_time;

    public float start_wait_time;
    private float wait_time;

    private int walk_direction;

    public Collider2D walk_zone;
    private Vector2 min_walk_point;
    private Vector2 max_walk_point;
    private bool has_walk_zone;

	// Use this for initialization
	void Start () {
        my_rigid_body = GetComponent<Rigidbody2D>();

        wait_time = start_walk_time;
        walk_time = start_walk_time;

        ChooseDirection();

        if (walk_zone != null)
        {
            min_walk_point = walk_zone.bounds.min;
            max_walk_point = walk_zone.bounds.max;
            has_walk_zone = true;
        }
	}
	
	// Update is called once per frame
	void Update () {
		if (is_walking)
        {
            walk_time -= Time.deltaTime;

            switch (walk_direction)
            {
                case 0:
                    my_rigid_body.velocity = new Vector2(0, move_speed);
                    if (has_walk_zone && transform.position.y > max_walk_point.y)
                    {
                        is_walking = false;
                        wait_time = start_wait_time;
                    }
                    break;
                case 1:
                    my_rigid_body.velocity = new Vector2(move_speed, 0);
                    if (has_walk_zone && transform.position.x > max_walk_point.x)
                    {
                        is_walking = false;
                        wait_time = start_wait_time;
                    }
                    break;
                case 2:
                    my_rigid_body.velocity = new Vector2(0, -move_speed);
                    if (has_walk_zone && transform.position.y < min_walk_point.y)
                    {
                        is_walking = false;
                        wait_time = start_wait_time;
                    }
                    break;
                case 3:
                    my_rigid_body.velocity = new Vector2(-move_speed, 0);
                    if (has_walk_zone && transform.position.x < min_walk_point.x)
                    {
                        is_walking = false;
                        wait_time = start_wait_time;
                    }
                    break;
            }

            if (walk_time < 0)
            {
                is_walking = false;
                wait_time = start_wait_time;
                
            }

        } else
        {
            my_rigid_body.velocity = Vector2.zero;

            wait_time -= Time.deltaTime;
            if (wait_time < 0)
            {
                ChooseDirection();
            }
        }
	}

    public void ChooseDirection()
    {
        walk_direction = Random.Range(0, 4);
        is_walking = true;

        walk_time = start_walk_time;
    }

}
