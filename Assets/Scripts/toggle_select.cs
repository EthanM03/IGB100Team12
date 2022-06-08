using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class toggle_select : MonoBehaviour
{
    
    int diff = 3;
    public GameObject room;
    
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    
    // Start is called before the first frame update
    void Start()
    {
             
    }

    // Update is called once per frame
    void Update()
    {
        
        if (SceneManager.GetActiveScene().name == "MainLevel")
        {
            room = GameObject.Find("RoomGenerator");
            room.GetComponent<RoomGeneration>().maxPath = diff;
        }
    }    

    public void easy()
    {
        diff = 3;        
    }
    public void normal()
    {
        diff = 4;        
    }
    public void Hard()
    {
        diff = 5;
    }

}
