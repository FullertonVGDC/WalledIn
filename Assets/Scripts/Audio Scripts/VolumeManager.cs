using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeManager : MonoBehaviour {

    public VolumeController[] volume_controller_objects;

    public float max_volume_level = 1.0f;
    public float current_volume_level;

	// Use this for initialization
	void Start () {
        volume_controller_objects = FindObjectsOfType<VolumeController>();

        if (current_volume_level > max_volume_level)
        {
            current_volume_level = max_volume_level;
        }

        for (int i = 0; i < volume_controller_objects.Length; i++)
        {
            volume_controller_objects[i].SetAudioLevel(current_volume_level);
        }

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
