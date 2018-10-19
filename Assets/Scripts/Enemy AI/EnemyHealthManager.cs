using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour {

    //public float start_knockback_time;
    //private float knockback_time;
    //public float knockback_force;

    //private Vector3 move_direction;

    public int enemy_max_health;

    public int enemy_current_health;

    public float start_dazed_time;
    private float dazed_time;

    private EnemyController the_enemy;
    //public float start_knock_back_time;
    //private float knock_back_time;
    //public float knock_back_thrust;
    //public bool knockback;

    // Use this for initialization
    void Start () {
        enemy_current_health = enemy_max_health;

        the_enemy = gameObject.GetComponent<EnemyController>();
	}
	
	// Update is called once per frame
	void Update () {

        if (dazed_time < 0)
        {
            gameObject.GetComponent<EnemyFollowAI>().move_speed = 10;
        } else
        {
            dazed_time -= Time.deltaTime;

            gameObject.GetComponent<EnemyFollowAI>().move_speed = 0;
        }


		if (enemy_current_health <= 0)
        {
            //gameObject.SetActive(false);
            gameObject.GetComponent<EnemyController>().gameObject.SetActive(false);
            Destroy(gameObject.GetComponent<EnemyController>().gameObject);
            gameObject.SetActive(false);
            Destroy(gameObject);
            //Destroy(the_enemy.gameObje
        }

	}

    public void HurtEnemy(int damage_to_give, Vector3 direction)
    {
        dazed_time = start_dazed_time;

        enemy_current_health -= damage_to_give;

        the_enemy.Knockback(direction);
        
    }
    //public void Knockback(Vector3 direction)
    //{
    //    knockback_time = start_knockback_time;
    //    //direction = new Vector3(1f, 1f, 0f);
    //    move_direction = direction * knockback_force;
    //    gameObject.GetComponent<Rigidbody2D>().velocity = move_direction;
    //}
}
