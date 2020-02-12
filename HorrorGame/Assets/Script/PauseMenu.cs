using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class PauseMenu : MonoBehaviour
{
    public bool GameIsPaused = false;

    public void Start()
    {
        if (GameIsPaused == false)
        {
            Resume();
        }
        else
        {
            Pause();
        }
        GameIsPaused = true;
    }
 
    public GameObject pauseMenuUI;

    void Update() 
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false; 
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;

    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void QuitGame()
    {
        Time.timeScale = 0f;
        Application.Quit();
    }

    public void Controller()
    {
        SceneManager.LoadScene("Controller");
    }







}

