using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {


    public Slider healthBar;
    public Text HPText;
    public PlayerHealthManager playerHealth;
    private static bool UIExists;

	// Use this for initialization
	void Start () {

        if (!UIExists)
       {
           UIExists = true;
           DontDestroyOnLoad(transform.gameObject);
       }

       else
       {
           Destroy(gameObject);
       }


    }

    // Update is called once per frame
    void Update () {
        healthBar.maxValue = playerHealth.player_max_health;
        healthBar.value = playerHealth.player_current_health;
        HPText.text = "HP: " + playerHealth.player_current_health + " / " + playerHealth.player_max_health;
	}
}
