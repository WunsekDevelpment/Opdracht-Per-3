using Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal.Internal;

public class PauseMenuScript : MonoBehaviour
{
    public Canvas pauseMenu;
    public Canvas mainMenu;
    public Canvas hud;
    public GameObject player;
    public Camera mainCam;
    public bool inMainMenu;
    public bool inPauseMenu;


    

    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (mainMenu.GetComponent<Canvas>().enabled == true)
        {
            inMainMenu = true;
        }
        else
        {
            inMainMenu = false;
        }
        if (pauseMenu.GetComponent<Canvas>().enabled == true)
        {
            inPauseMenu = true;
        }
        else
        {
            inPauseMenu = false;
        }
        if (inPauseMenu)
        {
            player.GetComponent<PlayerMovement>().enabled = false;
            mainCam.GetComponent<PlayerCam>().enabled = false;
            hud.GetComponent<Canvas>().enabled = false;
        }
        else
        {
            player.GetComponent <PlayerMovement>().enabled = true;
            mainCam.GetComponent<PlayerCam>().enabled = true;
            hud.GetComponent<Canvas>().enabled = true;
        }
        if (mainMenu)
        {
            hud.GetComponent<Canvas>().enabled = false;
        }
        if (pauseMenu.GetComponent<Canvas>().enabled == false && mainMenu.GetComponent<Canvas>().enabled == false) 
        {
            hud.GetComponent<Canvas>().enabled = true;
        }

        if (Input.GetKeyDown(KeyCode.Tab) && !inMainMenu)
        {
           
           pauseMenu.enabled = !pauseMenu.enabled;
        }
    }
    


}
