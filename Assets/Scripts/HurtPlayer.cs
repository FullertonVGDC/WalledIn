using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayer : MonoBehaviour {

    public int damage_to_give;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Vector3 hit_direction = other.transform.position - transform.position;
            hit_direction = hit_direction.normalized;

            other.gameObject.GetComponent<PlayerHealthManager>().HurtPlayer(damage_to_give, hit_direction);
            //other.gameObject.GetComponent<PlayerController>().Knockback(new Vector3(1f, 1f, 0f));
        }
    }

}
