using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 

public class DialogueManager : MonoBehaviour
{
    [SerializeField] private GameObject dialogueUI;
    [SerializeField] private TextMeshProUGUI speakerText;
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private float typingSpeed = 0.05f;

    // Add this line to declare the array for scripts to disable
    [SerializeField] private MonoBehaviour[] scriptsToDisableDuringDialogue;

    private string[] currentDialogueLines;
    private int currentLineIndex;
    private bool isTyping;
    private Coroutine typingCoroutine;

    private void Start()
    {
        dialogueUI.SetActive(false); // Dialogue UI starts hidden
    }

    public void StartDialogue(string speakerName, string[] lines)
    {
        currentDialogueLines = lines;
        currentLineIndex = 0;
        dialogueUI.SetActive(true);
        speakerText.text = speakerName;

        // Disable all specified scripts during dialogue
        foreach (var script in scriptsToDisableDuringDialogue)
        {
            if (script != null) script.enabled = false;
        }

        DisplayNextLine();
    }

    private void Update()
    {
        if (dialogueUI.activeSelf && Input.GetKeyDown(KeyCode.Space) && !isTyping)
        {
            DisplayNextLine();
        }
    }

    private void DisplayNextLine()
    {
        if (currentLineIndex < currentDialogueLines.Length)
        {
            if (typingCoroutine != null)
            {
                StopCoroutine(typingCoroutine);
            }
            typingCoroutine = StartCoroutine(TypeLine(currentDialogueLines[currentLineIndex]));
            currentLineIndex++;
        }
        else
        {
            EndDialogue();
        }
    }

    private IEnumerator TypeLine(string line)
    {
        isTyping = true;
        dialogueText.text = "";

        foreach (char letter in line.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }

        isTyping = false;
    }

    private void EndDialogue()
    {
        dialogueUI.SetActive(false);
        currentDialogueLines = null;
        currentLineIndex = 0;

        // Re-enable all specified scripts when dialogue ends
        foreach (var script in scriptsToDisableDuringDialogue)
        {
            if (script != null) script.enabled = true;
        }
    }
}
