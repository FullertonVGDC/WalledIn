using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateTextAtLine : MonoBehaviour {

    public TextAsset the_text;

    public int start_line;
    public int end_line;

    public TextBoxManager the_text_box;

    public bool destroy_when_activated;

    public bool require_button_press;
    private bool wait_for_press;

	// Use this for initialization
	void Start () {
        the_text_box = FindObjectOfType<TextBoxManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
        if (wait_for_press && Input.GetKeyDown(KeyCode.Comma))
        {
            the_text_box.ReloadScript(the_text);
            the_text_box.current_line = start_line;
            the_text_box.end_at_line = end_line;
            the_text_box.EnableTextBox();

            if (destroy_when_activated)
            {
                Destroy(gameObject);
            }
        }

	}

    void OnTriggerEnter2D(Collider2D other)
    {
         if (other.name == "Player")
        {
            if (require_button_press)
            {
                wait_for_press = true;
                return;
            }

            the_text_box.ReloadScript(the_text);
            the_text_box.current_line = start_line;
            the_text_box.end_at_line = end_line;
            the_text_box.EnableTextBox();

            if (destroy_when_activated)
            {
                Destroy(gameObject);
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            wait_for_press = false;
        }
    }


}
