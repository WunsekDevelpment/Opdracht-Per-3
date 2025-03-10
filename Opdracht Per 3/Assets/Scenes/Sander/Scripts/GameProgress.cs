using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameProgress : MonoBehaviour
{
    public static GameProgress Instance { get; private set; } // Singleton
    public bool hasTalkedToNPC2 = false; // Tracks if NPC 2 was spoken to

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Persists across scenes (optional)
        }
        else
        {
            Destroy(gameObject); // Ensures only one instance exists
        }
    }
}
