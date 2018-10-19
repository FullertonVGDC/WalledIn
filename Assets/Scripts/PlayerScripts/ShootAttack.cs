using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootAttack : MonoBehaviour {

    public Transform fire_point;

    public GameObject bullet_prefab;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
	}
    
    void Shoot()
    {
        Instantiate(bullet_prefab, fire_point.position, fire_point.rotation);
    }
}
