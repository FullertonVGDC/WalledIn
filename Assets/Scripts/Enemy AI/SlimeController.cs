using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SlimeController : MonoBehaviour {

    public float move_speed;

    private Rigidbody2D my_rigid_body;

    private bool moving;

    public float time_between_move;
    private float time_between_move_counter;
    public float time_to_move;
    private float time_to_move_counter;

    private Vector3 move_direction;

    public float wait_to_reload;

    private bool reloading;

    private GameObject the_player;
	// Use this for initialization
	void Start () {
        my_rigid_body = GetComponent<Rigidbody2D>();

        //time_between_move_counter = time_between_move;
        //time_to_move_counter = time_to_move;

        time_between_move_counter = Random.Range(time_between_move * 0.7f, time_between_move * 1.25f);
        time_to_move_counter = Random.Range(time_to_move * 0.7f, time_to_move * 1.25f);
	}

    // Update is called once per frame
    void Update()
    {
        if (moving)
        {
            time_to_move_counter -= Time.deltaTime;
            my_rigid_body.velocity = move_direction;

            if (time_to_move_counter < 0f)
            {
                moving = false;
                //time_between_move_counter = time_between_move;
                time_between_move_counter = Random.Range(time_between_move * 0.7f, time_between_move * 1.25f);
            }
        }
        else
        {
            time_between_move_counter -= Time.deltaTime;

            my_rigid_body.velocity = Vector2.zero;

            if (time_between_move_counter < 0f)
            {
                moving = true;

                //time_to_move_counter = time_to_move; 
                time_to_move_counter = Random.Range(time_to_move * 0.7f, time_to_move * 1.25f);

                move_direction = new Vector3(Random.Range(-1f, 1f) * move_speed, Random.Range(-1f, 1f) * move_speed, 0f);
            }
        }



    }

}
