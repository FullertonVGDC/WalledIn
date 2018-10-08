using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {


    public float move_speed;

    private Animator anim;

    private bool player_moving;

    public Vector2 last_move;

    private Rigidbody2D my_rigid_body;

    private static bool player_exists;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        my_rigid_body = GetComponent<Rigidbody2D>();

        if (!player_exists)
        {
            player_exists = true;
            DontDestroyOnLoad(transform.gameObject);
        }

        else
        {
            Destroy(gameObject);
        }
    
	}
	
	// Update is called once per frame
	void Update () {

        player_moving = false;

		if (Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f)
        {
            //transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * move_speed * Time.deltaTime, 0f, 0f));

            my_rigid_body.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * move_speed, my_rigid_body.velocity.y);
            last_move = new Vector2(Input.GetAxisRaw("Horizontal"), 0f);
            player_moving = true;
        }
        if(Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f)
        {
            //transform.Translate(new Vector3(0f, Input.GetAxisRaw("Vertical") * move_speed * Time.deltaTime, 0f));

            my_rigid_body.velocity = new Vector2(my_rigid_body.velocity.x, Input.GetAxisRaw("Vertical") * move_speed);
            last_move = new Vector2(0f, Input.GetAxisRaw("Vertical"));
            player_moving = true;
        }

        if(Input.GetAxisRaw("Horizontal") < 0.5f && Input.GetAxisRaw("Horizontal") > -0.5f)
        {
            my_rigid_body.velocity = new Vector2(0f, my_rigid_body.velocity.y);
        }
        if(Input.GetAxisRaw("Vertical") < 0.5f && Input.GetAxisRaw("Vertical") > -0.5f)
        {
            my_rigid_body.velocity = new Vector2(my_rigid_body.velocity.x, 0f);
        }

        anim.SetFloat("MoveX", Input.GetAxisRaw("Horizontal"));
        anim.SetFloat("MoveY", Input.GetAxisRaw("Vertical"));
        anim.SetFloat("LastMoveX", last_move.x);
        anim.SetFloat(("LastMoveY"), last_move.y);
        anim.SetBool("PlayerMoving", player_moving);

	}
}
