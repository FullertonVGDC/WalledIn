using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallEnemy : MonoBehaviour
{
    private Animator anim;
    private bool is_walking;

    public float move_speed;
   

    private Rigidbody2D my_rigid_body;

    private bool moving;

    public float time_between_move;
    private float time_between_move_counter;
    public float time_to_move;
    private float time_to_move_counter;

    private int move_direction;
    private Vector2 direction;
    public Vector2 last_move;

    public float knockback_force;
    public float start_knockback_time;
    private float knockback_time;

    public Transform target;

    private float difference;

    // Use this for initialization
    void Start()
    {
        my_rigid_body = GetComponent<Rigidbody2D>();

        anim = GetComponent<Animator>();

        //For WanderAI
        time_between_move_counter = Random.Range(time_between_move * 0.7f, time_between_move * 1.25f);
        time_to_move_counter = Random.Range(time_to_move * 0.7f, time_to_move * 1.25f);
        //For ChaseAI
        //target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

    }

    // Update is called once per frame
    void Update()
    {

        if (knockback_time <= 0)
        {
            if (moving)
            {
                

                time_to_move_counter -= Time.deltaTime;
                // my_rigid_body.velocity = move_direction;
                if (move_direction == 1)
                {
                    my_rigid_body.velocity = Vector2.left * move_speed;

                    direction = new Vector2(-1, 0);
                    last_move = new Vector2(-1, 0);
                }
                else if (move_direction == 2)
                {
                    my_rigid_body.velocity = Vector2.right * move_speed;

                    direction = new Vector2(1, 0);
                    last_move = new Vector2(1, 0);
                }
                else if (move_direction == 3)
                {
                    my_rigid_body.velocity = Vector2.up * move_speed;

                    direction = new Vector2(0, 1);
                    last_move = new Vector2(0, 1);
                }
                else if (move_direction == 4)
                {
                    my_rigid_body.velocity = Vector2.down * move_speed;

                    direction = new Vector2(0, -1);
                    last_move = new Vector2(0, -1);
                }
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

                direction = Vector2.zero;

                if (time_between_move_counter < 0f)
                {
                    moving = true;

                    //time_to_move_counter = time_to_move; 
                    time_to_move_counter = Random.Range(time_to_move * 0.7f, time_to_move * 1.25f);

                    move_direction = Random.Range(1, 4);
                }
            }

            anim.SetFloat("MoveX", direction.x);
            anim.SetFloat("MoveY", direction.y);
            anim.SetFloat("LastMoveX", last_move.x);
            anim.SetFloat(("LastMoveY"), last_move.y);
            anim.SetBool("IsMoving", moving);

        }
        else
        {
            Debug.Log("Enemy Receiving Knockback");

            knockback_time -= Time.deltaTime;
        }

    }


   

    public void Knockback(Vector3 direction)
    {
        knockback_time = start_knockback_time;
        //direction = new Vector3(1f, 1f, 0f);
        //move_direction = direction * knockback_force;
        Vector2 knockback_thrust = direction * knockback_force;
        //gameObject.GetComponent<Rigidbody2D>().velocity = move_direction;
        gameObject.GetComponent<Rigidbody2D>().velocity = knockback_thrust;
    }
}
