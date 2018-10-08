using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStartPoint : MonoBehaviour {

    private PlayerController the_player;

    private CameraController the_camera;

    public Vector2 start_direction;
	// Use this for initialization
	void Start () {
        the_player = FindObjectOfType<PlayerController> ();
        the_player.transform.position = transform.position;
        the_player.last_move = start_direction;

        the_camera = FindObjectOfType<CameraController> ();
        the_camera.transform.position = new Vector3(transform.position.x, transform.position.y, the_camera.transform.position.z);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
