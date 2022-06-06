using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Loading : MonoBehaviour
{
    AsyncOperation loadingOperation;
    // Start is called before the first frame update
    void Start()
    {
        loadingOperation = SceneManager.LoadSceneAsync(2, LoadSceneMode.Single);
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
    }
    
}
