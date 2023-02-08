using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public DialogueHandler dialogue;

    public void TriggerDialogue()
    {
        FindObjectOfType<ChatManager>().DialogueStart(dialogue);
    }

    public void NextDialogue()
    {
        FindObjectOfType<ChatManager>().NextSentence();
    }

    public void EndDialogue()
    {
        FindObjectOfType<ChatManager>().EndDialogue();
    }
}
