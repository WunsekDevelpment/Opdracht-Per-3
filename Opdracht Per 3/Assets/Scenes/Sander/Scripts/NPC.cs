using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    [SerializeField] private string npcName; // NPC's name set in Inspector
    [TextArea(3, 10)]
    [SerializeField] private string[] dialogueLines; // Dialogue lines set in Inspector
    [SerializeField] private float interactionRange = 3f;

    private Transform player;
    private DialogueManager dialogueManager;
    private bool isPlayerInRange;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        dialogueManager = player.GetComponent<DialogueManager>(); // Get DialogueManager from player
    }

    private void Update()
    {
        float distance = Vector3.Distance(transform.position, player.position);
        isPlayerInRange = distance <= interactionRange;

        if (isPlayerInRange && Input.GetKeyDown(KeyCode.F))
        {
            dialogueManager.StartDialogue(npcName, dialogueLines); // Pass name and lines directly
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, interactionRange);
    }
}
