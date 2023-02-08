using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChatManager : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI DialogueText;
    public GameObject ChatUI;

    private Queue<string> sentences;

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }

    public void DialogueStart(DialogueHandler dialogue)
    {
        ChatUI.SetActive(true);

        nameText.text = dialogue.name;

        sentences.Clear();

        foreach(string sentence in dialogue.sentances)
        {
            sentences.Enqueue(sentence);
        }

        NextSentence();
    }

    public void NextSentence()
    {
        if(sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        string sentence = sentences.Dequeue();
        DialogueText.text = sentence;
    }

    public void EndDialogue()
    {
        ChatUI.SetActive(false);
        Debug.Log("Stop chatting");
    }
}
