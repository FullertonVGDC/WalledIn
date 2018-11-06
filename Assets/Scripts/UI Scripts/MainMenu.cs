using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour {

    public string start_level;

    public string level_select;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void NewGame()
    {
        SceneManager.LoadScene(start_level);
    }

    public void Continue()
    {
        SceneManager.LoadScene(level_select);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
