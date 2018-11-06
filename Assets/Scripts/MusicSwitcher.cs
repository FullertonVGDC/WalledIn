using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicSwitcher : MonoBehaviour {

    private MusicController the_music_controller;

    public int new_track;

    public bool switch_on_start;

	// Use this for initialization
	void Start () {
        the_music_controller = FindObjectOfType<MusicController>();

        if (switch_on_start)
        {
            the_music_controller.SwitchTrack(new_track);
            gameObject.SetActive(false);
        }

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            the_music_controller.SwitchTrack(new_track);
            gameObject.SetActive(false);
        }
    }
}
