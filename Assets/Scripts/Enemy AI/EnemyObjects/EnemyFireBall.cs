using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFireBall : MonoBehaviour {

    public float bullet_speed;

    public Rigidbody2D my_rigid_body;

    public Vector2 enemy_direction;

    public int damage_to_give;

    public float destroy_fireball_time;

    // Use this for initialization
    void Start()
    {
        enemy_direction = FindObjectOfType<FireBallEnemy>().last_move;
        //enemy_direction = FindObjectOfType<EnemyShootAttack>().shoot_direction;

        if (enemy_direction == new Vector2(0, 1))
        {
            transform.Rotate(0, 0, 90);
            my_rigid_body.velocity = Vector2.up * bullet_speed;
        }
        else if (enemy_direction == new Vector2(1, 0))
        {
            transform.Rotate(0, 0, 0);
            my_rigid_body.velocity = Vector2.right * bullet_speed;
        }
        else if (enemy_direction == new Vector2(0, -1))
        {
            transform.Rotate(0, 0, 270);
            my_rigid_body.velocity = Vector2.down * bullet_speed;
        }
        else if (enemy_direction == new Vector2(-1, 0))
        {
            transform.Rotate(0, 0, 180);
            my_rigid_body.velocity = Vector2.left * bullet_speed;
        }

        StartCoroutine(FireBallDestroyCounter());

    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void SetFireBallEnemy(FireBallEnemy the_fireball_enemy)
    {
        enemy_direction = the_fireball_enemy.last_move;
    }

    public void SetShootDirection(Vector2 shoot_direction)
    {
        Debug.Log("Set SHoot Direction");

        enemy_direction = shoot_direction;
    }

    IEnumerator FireBallDestroyCounter()
    {
        yield return new WaitForSeconds(destroy_fireball_time);
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log(other.name);

            PlayerHealthManager enemy = other.GetComponent<PlayerHealthManager>();
            if (enemy != null)
            {
                Vector3 hit_direction = other.transform.position - transform.position;
                hit_direction = hit_direction.normalized;

                //enemy.HurtEnemy(damage_to_give, hit_direction);
                other.GetComponent<PlayerHealthManager>().HurtPlayer(damage_to_give, hit_direction);
            }
            Destroy(gameObject);
        }

    }
}
