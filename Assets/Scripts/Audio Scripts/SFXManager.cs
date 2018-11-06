using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour {

    public AudioSource hit_effect;
    public AudioSource enemy_dead;
    public AudioSource sword_slash;

    private static bool sfx_manager_exists;
	// Use this for initialization
	void Start () {
        if (!sfx_manager_exists)
        {
            sfx_manager_exists = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
