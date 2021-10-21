using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public string levelToLoad;

    public void goToNewScene(string sceneName)
    {
        if (sceneName == "GameScene")
        {
            if (SceneManager.GetActiveScene().name == "Main Menu")
            {
                GameObject.FindGameObjectWithTag("MenuMusic").GetComponent<MusicScript>().StopMusic();

            }
        }
        if (sceneName == "ShopScene")
        {
            if (SceneManager.GetActiveScene().name == "Main Menu")
            {
                GameObject.FindGameObjectWithTag("MenuMusic").GetComponent<MusicScript>().StopMusic();

            }
        }
        if (sceneName == "Main Menu")
        {
            if (SceneManager.GetActiveScene().name == "ShopScene")
            {
                GameObject.FindGameObjectWithTag("MenuMusic").GetComponent<MusicScript>().PlayMusic();
            }
        }
        SceneManager.LoadScene(sceneName);
    }
}
