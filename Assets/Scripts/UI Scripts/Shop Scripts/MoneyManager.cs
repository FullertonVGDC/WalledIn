using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyManager : MonoBehaviour {
    public Text money_text;
    public int current_gold;

	// Use this for initialization
	void Start () {

        if (PlayerPrefs.HasKey("current_money"))
        {
            current_gold = PlayerPrefs.GetInt("current_money");
        } else
        {
            current_gold = 0;
            PlayerPrefs.SetInt("current_money", 0);
        }

        money_text.text = "Coins: " + current_gold;

     }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void AddMoney (int gold_to_add)
    {
        current_gold += gold_to_add;
        PlayerPrefs.SetInt("current_money", gold_to_add);
        money_text.text = "Coins: " + current_gold;
    }
}
