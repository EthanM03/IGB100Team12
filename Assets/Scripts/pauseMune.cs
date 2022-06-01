using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseMune : MonoBehaviour
{
    public static bool GameisPaused = false;

    public GameObject menuPausedUI;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameisPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        menuPausedUI.SetActive(false);
        Time.timeScale = 1f;
        GameisPaused = false;
    }
    void Pause()
    {
        menuPausedUI.SetActive(true);
        Time.timeScale = 0f;
        GameisPaused = true;
    }


    //public void controls()
    //{
    //    Time.timeScale = 1f;
    //    SceneManager.LoadScene("controls");
    //}
    //public void totorial1()
    //{
    //    Time.timeScale = 1f;
    //    SceneManager.LoadScene("totorial");
    //}
    //public void totorial2()
    //{
    //    Time.timeScale = 1f;
    //    SceneManager.LoadScene("totorial2");
    //}
    public void LevelLoad()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Main Menu");
    }
    public void LevelGameLoad()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainLevel");
    }

    public void QuitGame()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }
}
