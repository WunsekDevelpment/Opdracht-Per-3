using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurslorLockScript : MonoBehaviour
{
    public bool InMenu;
    public Canvas pausemenu;
    public Canvas mainmenu;

    void Start()
    {
        InMenu = true;
    }

    void Update()
    {
        if (pausemenu.GetComponent<Canvas>().enabled == true)
        {
            InMenu = true;
        }
        if (mainmenu.GetComponent<Canvas>().enabled == true)
        {
            InMenu = true;
        }
        if (pausemenu.GetComponent<Canvas>().enabled == false && mainmenu.GetComponent<Canvas>().enabled == false)
        {
            InMenu = false;
        } 
        if (!InMenu)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        if (InMenu)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
