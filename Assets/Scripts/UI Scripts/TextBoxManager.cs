using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextBoxManager : MonoBehaviour {

    public TextAsset text_file;
    public string[] text_lines;

    public GameObject text_box;
    public Text the_text;

    public int current_line;
    public int end_at_line;

    public PlayerController the_player;

    public bool is_active;

    public bool stop_player_movement;

    private bool is_typing = false;
    private bool cancel_typing;

    public float type_speed;

    // Use this for initialization
    void Start()
    {

        the_player = FindObjectOfType<PlayerController>();

        if (text_file != null)
        {
            text_lines = (text_file.text.Split('\n'));
        }

        if (end_at_line == 0)
        {
            end_at_line = text_lines.Length - 1;
        }

        if (is_active)
        {
            EnableTextBox();
        } else
        {
            DisableTextBox();
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (!is_active)
        {
            return;
        }

        //the_text.text = text_lines[current_line];

        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (!is_typing)
            {


                current_line += 1;

                if (current_line > end_at_line)
                {
                    DisableTextBox();
                } else
                {
                    StartCoroutine(TextScroll(text_lines[current_line]));
                }
            }
            else if (is_typing && !cancel_typing)
            {
                cancel_typing = true;
            }
        }

        //if (current_line > end_at_line)
        //{
        //    DisableTextBox();
        //}

    }

    private IEnumerator TextScroll(string line_of_text)
    {
        int letter = 0;
        the_text.text = "";
        is_typing = true;
        cancel_typing = false;
        while (is_typing && !cancel_typing && letter < line_of_text.Length - 1)
        {
            the_text.text += line_of_text[letter];
            letter += 1;
            yield return new WaitForSeconds(type_speed);
        }
        the_text.text = line_of_text;
        is_typing = false;
        cancel_typing = false;
    }

    public void EnableTextBox()
    {
        text_box.SetActive(true);

        is_active = true;

        if (stop_player_movement)
        {
            the_player.can_move = false;
        }

        StartCoroutine(TextScroll(text_lines[current_line]));

    }

    public void DisableTextBox()
    {

        is_active = false;

        text_box.SetActive(false);

        the_player.can_move = true;
    }

    public void ReloadScript(TextAsset the_text)
    {

        if (the_text != null)
        {
            text_lines = new string[1];

            text_lines = (the_text.text.Split('\n'));
        }

    }

}
