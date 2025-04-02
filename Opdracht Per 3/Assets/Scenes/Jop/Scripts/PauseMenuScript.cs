using Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuScript : MonoBehaviour
{
    public Canvas pauseCanvas;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        pauseCanvas.GetComponent<Canvas>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseCanvas.GetComponent<Canvas>().enabled = !pauseCanvas.GetComponent<Canvas>().enabled;
            player.GetComponent<PlayerMovement>().enabled = !player.GetComponent<PlayerMovement>().enabled;
        }
    }


}
