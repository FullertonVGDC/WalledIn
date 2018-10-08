using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public GameObject follow_target;
    private Vector3 target_pos;
    public float camera_speed;

    private static bool camera_exists;
	// Use this for initialization
	void Start () {
        if (!camera_exists)
        {
            camera_exists = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        target_pos = new Vector3(follow_target.transform.position.x, follow_target.transform.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, target_pos, camera_speed * Time.deltaTime);
	}
}
