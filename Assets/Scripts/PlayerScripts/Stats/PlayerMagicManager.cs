using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMagicManager : MonoBehaviour {

    public int player_max_magic;
    public int player_current_magic;

    // Use this for initialization
    void Start () {
        player_current_magic = player_max_magic;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void UseMagic (int magic_to_use)
    {
        player_current_magic -= magic_to_use;
    }
}
