using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootAttack : MonoBehaviour {

    public Transform fire_point;

    public GameObject bullet_prefab;

    public int magic_to_use;

    public PlayerMagicManager player_magic;

	// Use this for initialization
	void Start () {
        player_magic = GetComponent<PlayerMagicManager>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Fire1"))
        {
            if (player_magic.player_current_magic <= 0)
                return;
            else
            Shoot();
        }
	}
    
    void Shoot()
    {
        player_magic.UseMagic(magic_to_use);
        Instantiate(bullet_prefab, fire_point.position, fire_point.rotation);
    }
}
