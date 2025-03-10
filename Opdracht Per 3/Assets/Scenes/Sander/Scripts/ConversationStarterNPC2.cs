using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class ConversationStarterNPC2 : MonoBehaviour
{
    [SerializeField] private NPCConversation myConversation; // "Tell NPC 1 it’s all clear"

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                ConversationManager.Instance.StartConversation(myConversation);
                GameProgress.Instance.hasTalkedToNPC2 = true; // Set the flag
            }
        }
    }
}
