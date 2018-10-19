using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollowAI : MonoBehaviour {

    public float move_speed;

    private Transform target;

    public float stop_distance;

    private Rigidbody2D my_rigid_body;

    private float player_distance;

    public float chase_range;

    //public float start_recoil_time;
    //private float recoil_time;

    // Use this for initialization
    void Start () {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        my_rigid_body = GetComponent<Rigidbody2D>();

        //recoil_time = start_recoil_time;
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

    //private IEnumerator RecoilCounter(Rigidbody2D enemy)
    //{
    //    Debug.Log("Enemy Recoiling");
    //    enemy.velocity = Vector2.zero;
    //    yield return new WaitForSeconds(recoil_time);
       
    //}
}
