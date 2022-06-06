using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    //public Text highScore;

    // Start is called before the first frame update
    void Start()
    {
        //highScore.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
        Cursor.visible = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void loadScene(int scenceIndex)
    {
        SceneManager.LoadScene(scenceIndex);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
