using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectorNavigation : MonoBehaviour {

    public int index;

    public int number_of_selections;

    public float y_offset = 1f;

	// Use this for initialization
	void Start () {
		
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyUp(KeyCode.S))
        {
            if (index < number_of_selections - 1)
            {
                index++;
                Vector2 position = transform.position;
                position.y -= y_offset;
                transform.position = position;
            }
        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            if (index > 0)
            {
                index--;
                Vector2 position = transform.position;
                position.y += y_offset;
                transform.position = position;
            }
        }

        if (Input.GetKeyUp(KeyCode.Return))
        {
            
        }
    }
}
