using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class QuitScript : MonoBehaviour
{
    public void exitgame()
    {
        Debug.Log("exitgame");
        Application.Quit();
    }
}