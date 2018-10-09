using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashMove : MonoBehaviour {

    private Rigidbody2D my_rigid_body;
    public float dash_speed;
    private float dash_time;
    public float start_dash_time;
    private int direction;

	// Use this for initialization
	void Start () {
        my_rigid_body = GetComponent<Rigidbody2D>();
        dash_time = start_dash_time;
	}
	
	// Update is called once per frame
	void Update () {



        
            if (direction == 0)
            {
                if (Input.GetKey(KeyCode.A) && Input.GetKeyDown(KeyCode.RightShift))
                {
                   
                    direction = 1;

                }
                else if (Input.GetKey(KeyCode.D) && Input.GetKeyDown(KeyCode.RightShift))
                {
                   
                    direction = 2;
                }
                else if (Input.GetKey(KeyCode.W) && Input.GetKeyDown(KeyCode.RightShift))
                {
                   
                    direction = 3;
                }
                else if (Input.GetKey(KeyCode.S) && Input.GetKeyDown(KeyCode.RightShift))
                {
                  
                    direction = 4;
                }
            }

            else
            {
                if (dash_time <= 0)
                {
                    direction = 0;
                    dash_time = start_dash_time;
                    my_rigid_body.velocity = Vector2.zero;
                }
                else
                {
                    dash_time -= Time.deltaTime;

                    if (direction == 1)
                    {
                        my_rigid_body.velocity = Vector2.left * dash_speed;
                    }
                    else if (direction == 2)
                    {
                        my_rigid_body.velocity = Vector2.right * dash_speed;
                    }
                    else if (direction == 3)
                    {
                        my_rigid_body.velocity = Vector2.up * dash_speed;
                    }
                    else if (direction == 4)
                    {
                        my_rigid_body.velocity = Vector2.down * dash_speed;
                    }
                }
            }
        
	}
}
