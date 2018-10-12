using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LoadNewArea : MonoBehaviour {

    public string level_to_load;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        
        {
            SceneManager.LoadScene(level_to_load);
        }
    }
}
