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

    public PlayerController the_player;
	// Use this for initialization
	void Start () {
        player_current_health = player_max_health;

        player_sprite = GetComponent<SpriteRenderer>();

        the_player = FindObjectOfType<PlayerController>();
	}
	
	// Update is called once per frame
	void Update () {

		if (player_current_health < 0)
        {
            gameObject.SetActive(false);
        }


        if (player_flash_active)
        {
            if (flash_time > start_flash_time * 0.66f)
            {
                player_sprite.color = new Color(player_sprite.color.r, player_sprite.color.g, player_sprite.color.b, alpha);
            } else if (flash_time > start_flash_time * 0.33f)
            {
                player_sprite.color = new Color(player_sprite.color.r, player_sprite.color.g, player_sprite.color.b, 1f);
            } else if (flash_time > 0f)
            {
                player_sprite.color = new Color(player_sprite.color.r, player_sprite.color.g, player_sprite.color.b, alpha);
            }

            else
            {
                player_sprite.color = new Color(player_sprite.color.r, player_sprite.color.g, player_sprite.color.b, 1f);
                player_flash_active = false;
            }

            flash_time -= Time.deltaTime;

        }
	}

    public void HurtPlayer (int damage_to_give, Vector3 direction)
    {
        player_current_health -= damage_to_give;

        player_flash_active = true;

        flash_time = start_flash_time;

        the_player.Knockback(direction);
    }

    public void SetMaxHealth ()
    {
        player_current_health = player_max_health;
    }
}
