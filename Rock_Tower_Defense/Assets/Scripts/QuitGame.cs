using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitGame : MonoBehaviour
{
    public void exitgame()
    {
        Debug.Log("game quit");
        Application.Quit();
    }
}
