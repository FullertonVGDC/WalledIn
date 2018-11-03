using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {


    public Slider healthBar;
    public Text HPText;
    public PlayerHealthManager playerHealth;

    public Slider magic_bar;
    public Text magic_bar_text;
    public PlayerMagicManager player_magic;
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

        magic_bar.maxValue = player_magic.player_max_magic;
        magic_bar.value = player_magic.player_current_magic;
        magic_bar_text.text = "MP: " + player_magic.player_current_magic + " / " + player_magic.player_max_magic;
	}
}
