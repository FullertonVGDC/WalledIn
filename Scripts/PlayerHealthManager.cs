using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthManager : MonoBehaviour {

    public int player_max_health;

    public int player_current_health;




	// Use this for initialization
	void Start () {
        player_current_health = player_max_health;
	}
	
	// Update is called once per frame
	void Update () {
		if (player_current_health < 0)
        {
            gameObject.SetActive(false);
        }
	}

    public void HurtPlayer (int damage_to_give)
    {
        player_current_health -= damage_to_give;
    }

    /*public void SetMaxHealth ()
    {
        player_current_health = player_max_health;
    }*/
}
