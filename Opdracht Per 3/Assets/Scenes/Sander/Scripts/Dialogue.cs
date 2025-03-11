using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    public string npcName;              // The name of this NPC, set in the Inspector (e.g., "NPC1" or "NPC2")
    public string[] initialDialogue;    // Array of dialogue lines shown before talking to NPC2, set in Inspector
    public string[] afterDialogue;      // Array of dialogue lines shown after talking to NPC2, set for NPC1 only
    public bool hasSpokenToOtherNPC = false;  // Tracks if NPC2 has been spoken to (used by NPC1)

    private void Start()
    {
        // Ensure the GameObject has a collider
        if (GetComponent<Collider>() == null)  // Checks if this NPC doesn't already have a collider
        {
            gameObject.AddComponent<SphereCollider>();  // Adds a SphereCollider if none exists
        }
        // Make it a trigger
        GetComponent<Collider>().isTrigger = true;  // Sets the collider as a trigger so player can enter it
    }
}
