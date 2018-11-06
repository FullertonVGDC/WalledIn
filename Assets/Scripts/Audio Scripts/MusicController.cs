using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour {

    public static bool music_controller_exists;

    public AudioSource[] music_tracks;

    public int current_track;

    public bool music_can_play;
	// Use this for initialization
	void Start () {
		
        if (!music_controller_exists)
        {
            music_controller_exists = true;
            DontDestroyOnLoad(transform.gameObject);
        } else
        {
            Destroy(gameObject);
        }

	}
	
	// Update is called once per frame
	void Update () {
		if (music_can_play)
        {

            if (!music_tracks[current_track].isPlaying)
            {
                music_tracks[current_track].Play();
            }

        } else
        {
            music_tracks[current_track].Stop();
        }
	}

    public void SwitchTrack (int new_track)
    {
        music_tracks[current_track].Stop();
        current_track = new_track;

        music_tracks[current_track].Play();
    }
}
