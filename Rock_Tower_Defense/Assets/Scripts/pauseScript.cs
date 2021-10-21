using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class pauseScript : MonoBehaviour
{

    

    public static bool gamePause = false;
    public GameObject pauseMenuUI;

    public Button resumeButton, menuButton, quitButton;

    void Start()
    {

        resumeButton = GameObject.Find("resumeButton").GetComponent<Button>();
        menuButton = GameObject.Find("menuButton").GetComponent<Button>();
        quitButton = GameObject.Find("quitButton").GetComponent<Button>();

        pauseMenuUI = GameObject.FindGameObjectWithTag("pauseCanvas");
        pauseMenuUI.SetActive(false);


        resumeButton.onClick.AddListener(resumeGameButton);
        menuButton.onClick.AddListener(goMainMenuButton);
        quitButton.onClick.AddListener(QuitGame); 
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gamePause)
            {
                Resume();
                Debug.Log("resume");
            }
            else
            {
                Pause();
                Debug.Log("pause");
            }
        }
    }

    void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gamePause = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gamePause = true;
    }

    void resumeGameButton()
    {
        Resume();
    }

    void goMainMenuButton()
    {
        Resume();
        SceneManager.LoadScene("Main Menu");
    }

    void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quitting game, test.");
    }
}
