using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour {

    //public float start_knockback_time;
    //private float knockback_time;
    //public float knockback_force;

    //private Vector3 move_direction;

    public GameObject damage_burst;

    public int enemy_max_health;

    public int enemy_current_health;

    public float start_dazed_time;
    private float dazed_time;

    private EnemyController the_enemy;
    private FireBallEnemy the_fireball_enemy;
    public bool is_fireball_enemy;

    private SFXManager the_sfx_manager;
    private bool enemy_hit;
    //public float start_knock_back_time;
    //private float knock_back_time;
    //public float knock_back_thrust;
    //public bool knockback;

    // Use this for initialization
    void Start () {
        enemy_current_health = enemy_max_health;

        if (is_fireball_enemy)
            the_fireball_enemy = GetComponent<FireBallEnemy>();
        else
        the_enemy = gameObject.GetComponent<EnemyController>();

        the_sfx_manager = FindObjectOfType<SFXManager>();
	}
	
	// Update is called once per frame
	void Update () {
        //if (dazed_time < 0)
        //{
        //    gameObject.GetComponent<EnemyFollowAI>().move_speed = 10;
        //} else
        //{
        //    dazed_time -= Time.deltaTime;

        //    gameObject.GetComponent<EnemyFollowAI>().move_speed = 0;
        //}
        if (enemy_current_health <= 0)
            Debug.Log("Enemy Destroyed");

		if (enemy_current_health <= 0f)
        {
            Debug.Log("Enemy Destroyed");
            //gameObject.SetActive(false);
            // gameObject.GetComponent<EnemyController>().gameObject.SetActive(false);
            // Destroy(gameObject.GetComponent<EnemyController>().gameObject);
            // gameObject.SetActive(false);
            the_sfx_manager.enemy_dead.Play();

            Destroy(gameObject);
            //Destroy(the_enemy.gameObject)
        }

	}

    public void HurtEnemy(int damage_to_give, Vector3 direction)
    {
        the_sfx_manager.hit_effect.Play();

        dazed_time = start_dazed_time;

        enemy_current_health -= damage_to_give;

        if (is_fireball_enemy)
            the_fireball_enemy.Knockback(direction);
        else
        the_enemy.Knockback(direction);

        Instantiate(damage_burst, gameObject.transform.position, gameObject.transform.rotation);

       // enemy_hit = true;
    }
    //public void Knockback(Vector3 direction)
    //{
    //    knockback_time = start_knockback_time;
    //    //direction = new Vector3(1f, 1f, 0f);
    //    move_direction = direction * knockback_force;
    //    gameObject.GetComponent<Rigidbody2D>().velocity = move_direction;
    //}
}
