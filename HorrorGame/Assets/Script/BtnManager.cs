using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BtnManager : MonoBehaviour
{
    public void NewGameBtn(string newGame)
    {
        SceneManager.LoadScene("Intropart");
    }
    public void LoadGameBtn(string loadGame)
    {
        SceneManager.LoadScene(loadGame);
    }
    public void QuitGameBtn()
    {
        Application.Quit();
    }
    public void ControlBtn(string ControlBtn)
    {
        SceneManager.LoadScene("Controller");
    }
}
