using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayButtonScript : MonoBehaviour
{
    public Canvas mainMenu;
    public bool inMainMenu;
    void Start()
    {
        Time.timeScale = 0f;
        mainMenu.enabled = true;
        inMainMenu = true;
    }

    public void play()
    {
        mainMenu.enabled = false;
        Time.timeScale = 1f;
        inMainMenu = false;
    }

   
}
