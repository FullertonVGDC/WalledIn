using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthManager : MonoBehaviour {

    public int player_max_health;
    public int player_current_health;

    private bool player_flash_active;

    public float start_flash_time;
    private float flash_time;

    private SpriteRenderer player_sprite;
    public float alpha;

	// Use this for initialization
	void Start () {
        player_current_health = player_max_health;

        player_sprite = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {

		if (player_current_health < 0)
        {
            gameObject.SetActive(false);
        }

        if (player_flash_active)
        {
            if (flash_time < 0)
            {
                player_sprite.color = new Color(player_sprite.color.r, player_sprite.color.g, player_sprite.color.b, alpha);
                player_flash_active = false;
            }
        }
	}

    public void HurtPlayer (int damage_to_give)
    {
        player_current_health -= damage_to_give;

        player_flash_active = true;

        flash_time = start_flash_time;
    }

    public void SetMaxHealth ()
    {
        player_current_health = player_max_health;
    }
}
