using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class SceneChange : MonoBehaviour
{

    public string levelToLoad;
    
    public void goToNewScene(string sceneName)
    {
        if (sceneName == "Game")
        {
            GameObject.FindGameObjectWithTag("Music").GetComponent<MusicScript>().StopMusic();
            //GameObject.FindGameObjectWithTag("GameMusic").GetComponent<MusicScript>().PlayMusic();
        }
        if (sceneName == "Quit")
        {
            Character.Instance.playerDeath();
        }
        if (sceneName == "Quit2")
        {
            Application.Quit();
        }
        SceneManager.LoadScene(sceneName);
    }
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (levelToLoad == "Quit")
        {
            Character.Instance.playerDeath();
            SceneManager.LoadScene("Quit");
        }

        else if (other.gameObject.name == "Player")
        {
            SceneManager.LoadScene(levelToLoad);
        }
        else
        {
            return;
        }
    }
}
