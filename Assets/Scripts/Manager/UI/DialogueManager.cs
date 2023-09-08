using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public GameObject _dialoguePanel;
    public Text _dialogueText;

    private List<string> dialogueMessages = new List<string>();
    private int currentMessageIndex = 0;

    private void Start()
    {
        _dialoguePanel.SetActive(false);
    }

    public void StartDialogue(List<string> messages)
    {
        dialogueMessages = messages;
        currentMessageIndex = 0;
        ShowNextMessage();
    }

    public void ShowNextMessage()
    {
        if (currentMessageIndex < dialogueMessages.Count)
        {
            _dialogueText.text = dialogueMessages[currentMessageIndex];
            currentMessageIndex++;
        }
        else
        {
            _dialoguePanel.SetActive(false);
        }
    }
}
