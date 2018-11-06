using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeController : MonoBehaviour {

    private AudioSource the_audio;

    private float audio_level;

    public float default_audio;
    // Use this for initialization
    void Start () {
        the_audio = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetAudioLevel(float volume)
    {
        if (the_audio == null)
        {
            the_audio = GetComponent<AudioSource>();
        }

        audio_level = default_audio * volume;
        the_audio.volume = audio_level;
    }
}
