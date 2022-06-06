using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Loading : MonoBehaviour
{
    public Slider progressBar;
    AsyncOperation loadingOperation;
    // Start is called before the first frame update
    void Start()
    {
        //DontDestoryOnLoad(this);
        //Object.DontDestoryOnLoad(progressBar);
        loadingOperation = SceneManager.LoadSceneAsync(2, LoadSceneMode.Additive);
    }

    // Update is called once per frame
    void Update()
    {
        UpdateProgress();
    }
    public void UpdateProgress()
    {
        if (loadingOperation.isDone != true)
        {
            progressBar.value = Mathf.Clamp01(loadingOperation.progress/0.9f);
        }
        else
        {
            Destroy(progressBar);
        }
        
    }
    
}
