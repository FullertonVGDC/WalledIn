using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {
    private Animator anim;
    private bool is_walking;

    public bool can_wander;
    public bool can_patrol;
    public bool can_rush;
    public bool can_follow;
    public bool never_patrol;

    public float move_speed;
    public float follow_move_speed;

    private Rigidbody2D my_rigid_body;

    private bool moving;

    //For Wander AI
    public float time_between_move;
    private float time_between_move_counter;
    public float time_to_move;
    private float time_to_move_counter;

    private Vector3 move_direction;

    public float knockback_force;
    public float start_knockback_time;
    private float knockback_time;

    //For ChaseAI
    //private Transform target;
    public Transform target;
    public float stop_distance;
    private float player_distance;
    public float chase_range;


    //For RushAI
    private bool ready_to_rush;
    private bool ready_to_recoil;
    private bool ready_to_wait;

    

    public float rush_thrust;

    public float rush_distance;

    private float difference;

    public float start_rush_time;
    private float rush_time;
    public float start_recoil_time;
    private float recoil_time;
    public float start_wait_time;
    private float wait_time;


    public Transform[] move_spots;

    private int random_spot;

    public float start_patrol_wait_time;

    private float patrol_wait_time;
    // Use this for initialization
    void Start () {
        my_rigid_body = GetComponent<Rigidbody2D>();

        anim = GetComponent<Animator>();

        //For WanderAI
        time_between_move_counter = Random.Range(time_between_move * 0.7f, time_between_move * 1.25f);
        time_to_move_counter = Random.Range(time_to_move * 0.7f, time_to_move * 1.25f);
        //For ChaseAI
        //target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        //For RushAI
        rush_time = start_rush_time;
        recoil_time = start_recoil_time;
        wait_time = start_wait_time;

        //For PatrolAI
        random_spot = Random.Range(0, move_spots.Length);

        patrol_wait_time = Random.Range(start_patrol_wait_time * 0.7f, start_patrol_wait_time * 1.25f);
    }
	
	// Update is called once per frame
	void Update () {

        if (knockback_time <= 0)
        {
            
            if (can_wander)
            {
                if (moving)
                {
                    is_walking = true;

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
                    is_walking = false;

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

            if (can_follow)
            {
                player_distance = Vector3.Distance(target.position, transform.position);

                if (player_distance < chase_range)
                {
                    Debug.Log("Chasing Player");
                    if (Vector2.Distance(transform.position, target.position) > stop_distance)
                    {
                        is_walking = true;
                        Debug.Log("Chasing Player");
                        transform.position = Vector2.MoveTowards(transform.position, target.position, follow_move_speed * Time.deltaTime);

                    }

                }
            }

            if (can_rush)
            {
                difference = Vector3.Distance(target.transform.position, transform.position);

                if (difference < rush_distance)
                {
                    can_wander = false;
                    can_follow = false;
                    can_patrol = false;
                    // StartCoroutine(RecoilCounter(my_rigid_body));
                    //// StartCoroutine(RushCounter(my_rigid_body));
                    // my_rigid_body.velocity = Vector2.zero;

                    ready_to_recoil = true;
                }

                if (ready_to_recoil)
                {
                    is_walking = false;

                    Debug.Log("Enemy Recoiling");
                    my_rigid_body.velocity = Vector2.zero;
                    StartCoroutine(RecoilCounter());
                    // StartCoroutine(RushCounter(my_rigid_body));
                   // ready_to_rush = true;

                }

                if (ready_to_rush)
                {
                    is_walking = true;

                    ready_to_recoil = false;
                    Debug.Log("Enemy Rushing");

                    Vector2 distance = target.position - transform.position;
                    distance = distance.normalized * rush_thrust;

                    my_rigid_body.velocity = distance;

                    StartCoroutine(RushCounter());

                    //ready_to_wait = true;
                }
                if (ready_to_wait)
                {
                    is_walking = false;

                    Debug.Log("Enemy Waiting");
                    my_rigid_body.velocity = Vector2.zero;
                    ready_to_recoil = false;
                    ready_to_rush = false;
                    StartCoroutine(WaitCounter());

                    //ready_to_wait = false;
                    //can_wander = true;
                    //can_patrol = true;
                }
            }
            if (can_patrol && !never_patrol)
            {
                my_rigid_body.velocity = Vector2.zero;

                transform.position = Vector2.MoveTowards(transform.position, move_spots[random_spot].position, move_speed * Time.deltaTime);

                if (Vector2.Distance(transform.position, move_spots[random_spot].position) < 0.2f)
                {
                    if (patrol_wait_time <= 0)
                    {
                        is_walking = true;

                        random_spot = Random.Range(0, move_spots.Length);
                        patrol_wait_time = start_patrol_wait_time;
                    }
                    else
                    {
                        is_walking = false;

                        patrol_wait_time -= Time.deltaTime;
                    }
                }
            }

            anim.SetBool("IsWalking", is_walking);
        } else
        {
            Debug.Log("Enemy Receiving Knockback");

            knockback_time -= Time.deltaTime;
        }
	}

    private IEnumerator RecoilCounter()
    {
       // Debug.Log("Enemy Recoiling");
       // enemy.velocity = Vector2.zero;
        yield return new WaitForSeconds(recoil_time);
       

        ready_to_rush = true;
        //ready_to_recoil = false;
    }
    private IEnumerator RushCounter()
    {
        //Debug.Log("Enemy Rushing");
        //enemy.isKinematic = false;
        //gameObject.GetComponent<EnemyFollowAI>().enabled = false;
        //Vector2 distance = target.position - transform.position;
        //distance = distance.normalized * rush_thrust;

        //enemy.AddForce(distance, ForceMode2D.Impulse);
        yield return new WaitForSeconds(rush_time);
     
        ready_to_wait = true;

    }

    private IEnumerator WaitCounter()
    {
     
        yield return new WaitForSeconds(wait_time);

        ready_to_wait = false;
        can_wander = true;
        can_patrol = true;
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
