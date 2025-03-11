using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance;
    public TMP_Text dialogueText;
    public GameObject dialoguePanel;
    private string[] currentDialogue;
    private int dialogueIndex;
    private bool isTalking = false;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            Debug.Log("DialogueManager initialized");
        }
        else
        {
            Debug.LogWarning("Multiple DialogueManagers detected!");
        }
        if (dialoguePanel == null) Debug.LogError("DialoguePanel is not assigned!");
        if (dialogueText == null) Debug.LogError("DialogueText is not assigned!");
        dialoguePanel.SetActive(false);
        Debug.Log("Panel set inactive at start");
    }
    void Update()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void StartDialogue(string npcName, string[] dialogue)
    {
        Debug.Log("Starting dialogue for " + npcName);
        isTalking = true;
        dialoguePanel.SetActive(true);
        Debug.Log("Panel set active: " + dialoguePanel.activeSelf);
        currentDialogue = dialogue;
        dialogueIndex = 0;
        DisplayText(npcName);
        print(dialoguePanel.activeSelf);
    }

    public void NextLine()
    {
        Debug.Log("NextLine called");
        dialogueIndex++;
        if (dialogueIndex < currentDialogue.Length)
        {
            DisplayText("");
        }
        else
        {
            EndDialogue();
        }
    }

    private void DisplayText(string npcName)
    {
        string newText = npcName + ": " + currentDialogue[dialogueIndex];
        dialogueText.text = newText;
        Debug.Log("Text set to: " + newText);
    }

    private void EndDialogue()
    {
        Debug.Log("Ending dialogue");
        isTalking = false;
        dialoguePanel.SetActive(false);
        Debug.Log("Panel set inactive");
    }

    public bool IsTalking()
    {
        return isTalking;
    }
}

