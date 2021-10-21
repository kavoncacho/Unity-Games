using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class SceneChange : MonoBehaviour
{
    
    public void goToNewScene(string sceneName)
    {
        if ((sceneName == "Game") && (CharacterCreation.charCreated == true)) {
            SceneManager.LoadScene("Game");
        }
        else if ((sceneName == "Game") && (CharacterCreation.charCreated == false)){
            Debug.Log("Please make your character first");
        }
        else
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}
