using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour {
    public string level_select;
    public string main_menu;

    public bool is_paused;

    public GameObject pause_menu_canvas;

    public PlayerController the_player;
	// Use this for initialization
	void Start () {
        the_player = FindObjectOfType<PlayerController>();
	}
	
	// Update is called once per frame
	void Update () {
		if (is_paused)
        {
            the_player.GetComponent<PlayerController>().can_move = false;

            pause_menu_canvas.SetActive(true);

            Time.timeScale = 0f;
        } else
        {
            pause_menu_canvas.SetActive(false);
            the_player.GetComponent<PlayerController>().can_move = true;
            Time.timeScale = 1f;
        }

        if (Input.GetKeyUp(KeyCode.P))
        {
            is_paused = !is_paused;
        }
	}

    public void Resume()
    {
        is_paused = false;
    }
    public void LevelSelect()
    {
        SceneManager.LoadScene(level_select);
    }
    public void Quit()
    {
        Debug.Log("sceneName to load: " + main_menu);
        SceneManager.LoadScene("MainMenu");
    }
}
