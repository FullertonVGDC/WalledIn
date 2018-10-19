using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RushAI : MonoBehaviour {
    private bool ready_to_rush;
    private bool ready_to_recoil;
    private bool ready_to_wait;

    private Rigidbody2D my_rigid_body;

    private Transform target;

    public float rush_thrust;

    public float rush_distance;

    private float difference;

    public float start_rush_time;
    private float rush_time;
    public float start_recoil_time;
    private float recoil_time;
    public float start_wait_time;
    private float wait_time;
	// Use this for initialization
	void Start () {
        my_rigid_body = GetComponent<Rigidbody2D>();

        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        rush_time = start_rush_time;
        recoil_time = start_recoil_time;
        wait_time = start_wait_time;
    }
	
	// Update is called once per frame
	void Update () {
        difference = Vector3.Distance(target.transform.position, transform.position);

        if (difference < rush_distance)
        {
            // StartCoroutine(RecoilCounter(my_rigid_body));
            //// StartCoroutine(RushCounter(my_rigid_body));
            // my_rigid_body.velocity = Vector2.zero;
            ready_to_recoil = true;
        }

        if (ready_to_recoil)
        {
            StartCoroutine(RecoilCounter(my_rigid_body));
            // StartCoroutine(RushCounter(my_rigid_body));
            
        }

        if (ready_to_rush)
        {
            Debug.Log("Enemy Rushing");

            gameObject.GetComponent<EnemyFollowAI>().enabled = false;
            Vector2 distance = target.position - transform.position;
            distance = distance.normalized * rush_thrust;

            my_rigid_body.velocity = distance;

            StartCoroutine(RushCounter(my_rigid_body));

           
        }
        if (ready_to_wait)
        {
            Debug.Log("Enemy Waiting");
            ready_to_recoil = false;
            ready_to_rush = false;
            StartCoroutine(WaitCounter(my_rigid_body));
            ready_to_wait = false;
        }
    }

    private IEnumerator RecoilCounter(Rigidbody2D enemy)
    {
        Debug.Log("Enemy Recoiling");
        gameObject.GetComponent<SlimeController>().enabled = false;
        gameObject.GetComponent<EnemyFollowAI>().enabled = false;
        enemy.velocity = Vector2.zero;
        yield return new WaitForSeconds(recoil_time);
        gameObject.GetComponent<SlimeController>().enabled = true;

        ready_to_rush = true;
        //ready_to_recoil = false;
    }
    private IEnumerator RushCounter (Rigidbody2D enemy)
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

    private IEnumerator WaitCounter (Rigidbody2D enemy)
    {  
        enemy.velocity = Vector2.zero;
        yield return new WaitForSeconds(wait_time);
        gameObject.GetComponent<SlimeController>().enabled = true;
        gameObject.GetComponent<EnemyFollowAI>().enabled = true;
        
    }
   
}
