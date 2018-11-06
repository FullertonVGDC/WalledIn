using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public float bullet_speed;

    public Rigidbody2D my_rigid_body;

    public Vector2 player_direction;

    public int damage_to_give;

	// Use this for initialization
	void Start () {
        player_direction = FindObjectOfType<PlayerController>().last_move;

        if (player_direction == new Vector2(0, 1))
            my_rigid_body.velocity = Vector2.up * bullet_speed;
        
        else if (player_direction == new Vector2(1, 0))
            my_rigid_body.velocity = Vector2.right * bullet_speed;
        
        else if (player_direction == new Vector2(0, -1))
            my_rigid_body.velocity = Vector2.down * bullet_speed;
        
        else if (player_direction == new Vector2(-1, 0))
            my_rigid_body.velocity = Vector2.left * bullet_speed;
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log(other.name);

            EnemyHealthManager enemy = other.GetComponent<EnemyHealthManager>();
            if (enemy != null)
            {
                Vector3 hit_direction = other.transform.position - transform.position;
                hit_direction = hit_direction.normalized;

                //enemy.HurtEnemy(damage_to_give, hit_direction);
                other.GetComponent<EnemyHealthManager>().HurtEnemy(damage_to_give, hit_direction);
            }
            Destroy(gameObject);
        }
        
    }

}
