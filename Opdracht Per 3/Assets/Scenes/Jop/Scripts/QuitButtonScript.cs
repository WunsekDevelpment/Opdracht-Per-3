using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitButtonScript : MonoBehaviour
{
    public void quit()
    {
        Application.Quit();
        Debug.Log("Quit successfull");
    }
}
