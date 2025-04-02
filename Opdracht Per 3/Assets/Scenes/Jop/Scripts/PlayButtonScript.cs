using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayButtonScript : MonoBehaviour
{
    public Canvas mainMenu;
    void Start()
    {
        Time.timeScale = 0f;
        mainMenu.GetComponent<Canvas>().enabled = true;
    }

    public void play()
    {
        mainMenu.GetComponent<Canvas>().enabled = false;
        Time.timeScale = 1f;
    }

   
}
