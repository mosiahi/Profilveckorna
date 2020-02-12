using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Back : MonoBehaviour
{
    public GameObject pauseMenuUI;

    public void NewGame()
    {
        SceneManager.LoadScene("Intropart");
    }
}
