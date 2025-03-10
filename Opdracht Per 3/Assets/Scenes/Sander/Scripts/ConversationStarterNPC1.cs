using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class ConversationStarterNPC1 : MonoBehaviour
{
    [SerializeField] private NPCConversation myConversation;
    [SerializeField] private NPCConversation followUpConversation;

    private void Start()
    {
        Debug.Log("ConversationStarter is active on " + gameObject.name);
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player detected");
            if (Input.GetKeyDown(KeyCode.F))
            {
                Debug.Log("F pressed");
                if (GameProgress.Instance.hasTalkedToNPC2)
                {
                    ConversationManager.Instance.StartConversation(followUpConversation);
                }
                else
                {
                    ConversationManager.Instance.StartConversation(myConversation);
                }
            }
        }
    }
}
