using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrolAI : MonoBehaviour {

    public float move_speed;

    public Transform[] move_spots;

    private int random_spot;

    public float start_wait_time;

    private float wait_time;
	void Start () {
        random_spot = Random.Range(0, move_spots.Length);

        wait_time = Random.Range(start_wait_time * 0.7f, wait_time *1.25f);
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = Vector2.MoveTowards(transform.position, move_spots[random_spot].position, move_speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, move_spots[random_spot].position) < 0.2f)
        {
            if (wait_time <= 0)
            {
                random_spot = Random.Range(0, move_spots.Length);
                wait_time = start_wait_time;
            } else
            {
                wait_time -= Time.deltaTime;
            }
        }
	}
}
