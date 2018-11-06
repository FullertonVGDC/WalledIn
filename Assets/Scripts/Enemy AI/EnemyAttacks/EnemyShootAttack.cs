using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShootAttack : MonoBehaviour {

    public Transform fire_point;

    public GameObject bullet_prefab;

    private FireBallEnemy the_fireball_enemy;

    public float distance;

    private float rotation;
    public Vector2 shoot_direction;

    public float start_cooldown_time;
    private float cooldown_time;
    private bool cooldown_active;
    private bool can_not_shoot;

    // Use this for initialization
    void Start () {
        Physics2D.queriesStartInColliders = false;

        cooldown_time = start_cooldown_time;

        the_fireball_enemy = gameObject.GetComponent<FireBallEnemy>();
	}
	
	// Update is called once per frame
	void Update () {
        shoot_direction = the_fireball_enemy.last_move;

        if (shoot_direction == new Vector2(0, 1))
            fire_point.transform.Rotate(new Vector3(0, 0, 90));

        else if (shoot_direction == new Vector2(1, 0))
            fire_point.transform.Rotate(new Vector3(0, 0, 0));

        else if (shoot_direction == new Vector2(0, -1))
            fire_point.transform.Rotate(new Vector3(0, 0, 270));


        else if (shoot_direction == new Vector2(-1, 0))
            fire_point.transform.Rotate(new Vector3(0, 0, 180));

        RaycastHit2D hit_info = Physics2D.Raycast(fire_point.position, shoot_direction);

        //if (cooldown_active)
        //    StartCoroutine(CooldownTimer());

        if (hit_info)
        {
            if (hit_info.collider.CompareTag("Player"))
            {
                Debug.Log("Detected Player");



                if (can_not_shoot)
                    return;
                else
                    Shoot();
            }
        }
	}

    IEnumerator CooldownTimer()
    {
        Debug.Log("Cooldown Active");
        can_not_shoot = true;
       

        yield return new WaitForSeconds(cooldown_time);
        cooldown_active = false;
        can_not_shoot = false;
    }

    public void Shoot()
    {
        Debug.Log("Enemy Shooting");
        Instantiate(bullet_prefab, fire_point.position, transform.rotation);

        //bullet_prefab.gameObject.GetComponent<EnemyFireBall>().SetFireBallEnemy(the_fireball_enemy);
        //bullet_prefab.gameObject.GetComponent<EnemyFireBall>().SetShootDirection(shoot_direction);

        cooldown_active = true;
        StartCoroutine(CooldownTimer());
        
    }
}
