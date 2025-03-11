using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public Vector3 moveDir;
    public Vector3 playerRotate;
    public Vector3 camRotate;
    public float speed;
    public float sensitivity;
    public Transform cam;
    private Dialogue currentNPC;         // Reference to the NPC the player is near
    private Dialogue npc1;               // Reference to NPC1 for state tracking
    private Dialogue npc2;               // Reference to NPC2 for state tracking
    void Start()
    {
        // Find NPCs in the scene (assuming they have Dialogue component)
        Dialogue[] npcs = FindObjectsOfType<Dialogue>();  // Get all Dialogue components in scene
        foreach (Dialogue npc in npcs)                    // Loop through them
        {
            if (npc.npcName == "NPC1") npc1 = npc;       // Store NPC1 reference
            if (npc.npcName == "NPC2") npc2 = npc;       // Store NPC2 reference
        }
    }
    void Update()
    {
        moveDir.x = Input.GetAxis("Horizontal");

        moveDir.z = Input.GetAxis("Vertical");

        transform.Translate(moveDir * speed * Time.deltaTime);

        playerRotate.y = Input.GetAxis("Mouse X");

        camRotate.x = Input.GetAxis("Mouse Y");

        transform.Rotate(playerRotate * sensitivity * Time.deltaTime);

        cam.Rotate(-camRotate * sensitivity * Time.deltaTime);
        // Dialogue interaction
        if (currentNPC != null && Input.GetKeyDown(KeyCode.F) && !DialogueManager.Instance.IsTalking())
        // If near an NPC, F is pressed, and no conversation is active
        {
            Debug.Log("F pressed near " + currentNPC.npcName);
            string[] dialogueToShow;                  // Array to hold dialogue to display
            if (currentNPC == npc1)                   // If interacting with NPC1
            {
                dialogueToShow = npc1.hasSpokenToOtherNPC ? npc1.afterDialogue : npc1.initialDialogue;
                // Choose dialogue based on if NPC2 was spoken to
            }
            else                                      // If interacting with NPC2
            {
                dialogueToShow = currentNPC.initialDialogue;  // Use NPC2's initial dialogue
                if (currentNPC == npc2)               // If it is NPC2
                {
                    npc1.hasSpokenToOtherNPC = true;  // Update NPC1's state
                }
            }
            DialogueManager.Instance.StartDialogue(currentNPC.npcName, dialogueToShow);  // Start convo
        }

        if (DialogueManager.Instance.IsTalking() && Input.GetKeyUp(KeyCode.F))
        // If in a conversation and F is pressed
        {
            DialogueManager.Instance.NextLine();      // Advance to next line
        }
    }

    void OnTriggerEnter(Collider other)
    {
        Dialogue dialogue = other.GetComponent<Dialogue>();  // Check if collided with an NPC
        if (dialogue != null)                        // If it has a Dialogue component
        {
            currentNPC = dialogue;                   // Set as current NPC
            Debug.Log("Entered trigger of: " + dialogue.npcName);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Dialogue>() != null)  // If leaving an NPC's trigger
        {
            currentNPC = null;                       // Clear current NPC
            Debug.Log("Exited trigger");
        }
    }
}
