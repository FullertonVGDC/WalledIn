using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour {

    public int value;
    public MoneyManager the_money_manager;

	// Use this for initialization
	void Start () {
        the_money_manager = FindObjectOfType<MoneyManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            the_money_manager.AddMoney(value);
            Destroy(gameObject);
        }
    }
}
