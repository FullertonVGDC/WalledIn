using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour {

    public Dialogue dialogue;
    public bool immediate_trigger;
   // public bool is_shop_dialogue;

    private void Start()
    {
        if (immediate_trigger)
                FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        
    }

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }
}
