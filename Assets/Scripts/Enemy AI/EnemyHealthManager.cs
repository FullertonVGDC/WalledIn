using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour {

    public int enemy_max_health;

    public int enemy_current_health;

    public float start_dazed_time;
    private float dazed_time;

    // Use this for initialization
    void Start () {
        enemy_current_health = enemy_max_health;
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


		if (enemy_current_health < 0)
        {
            gameObject.SetActive(false);
        }
	}

    public void HurtEnemy(int damage_to_give)
    {
        dazed_time = start_dazed_time;

        enemy_current_health -= damage_to_give;
    }
}
