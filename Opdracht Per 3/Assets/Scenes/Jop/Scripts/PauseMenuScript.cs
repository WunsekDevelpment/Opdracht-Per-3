using Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal.Internal;

public class PauseMenuScript : MonoBehaviour
{
    public Canvas pauseMenu;
    public Canvas mainMenu;
    public GameObject player;
    public bool inMainMenu;
    

    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.GetComponent<Canvas>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (mainMenu.GetComponent<Canvas>())
        {
            inMainMenu = true;
        }
        if (Input.GetKeyDown(KeyCode.Escape) && !inMainMenu)
        {
            pauseMenu.GetComponent<Canvas>().enabled = !pauseMenu.GetComponent<Canvas>().enabled;
            player.GetComponent<PlayerMovement>().enabled = !player.GetComponent<PlayerMovement>().enabled;
        }
    }


}
