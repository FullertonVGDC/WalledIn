using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlashAttack : MonoBehaviour {

    public float start_cool_down_time;
    private float cool_down_time;

    public Transform attack_pos;
    public float attack_range;
    public int attack_box_x;
    public int attack_box_y;
    public LayerMask enemy_identifier;

    public int damage_to_give;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (cool_down_time < 0)
        {   //Then you can attack
            
            if (Input.GetKey(KeyCode.Period))
            {
                Collider2D[] enemies_to_damage = Physics2D.OverlapBoxAll(attack_pos.position, new Vector2(attack_box_x, attack_box_y), 0, enemy_identifier);
                
                for (int i = 0; i < enemies_to_damage.Length; i++)
                {
                    enemies_to_damage[i].GetComponent<EnemyHealthManager>().HurtEnemy(damage_to_give);
                }
            }

            cool_down_time = start_cool_down_time;

        } else
        {
            cool_down_time -= Time.deltaTime;
        }
	}

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(attack_pos.position, new Vector3(attack_box_x, attack_box_y, 1));
    }
}
