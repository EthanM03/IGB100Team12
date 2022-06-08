using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class menu_Audio : MonoBehaviour
{
    public AudioSource[] audioSource = new AudioSource[1];
    public AudioClip[] audioClip = new AudioClip[1];

    
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        audioClip[0] = Resources.Load<AudioClip>("Menu");
        
        audioSource[0] = gameObject.GetComponent<AudioSource>();       

        audioSource[0].clip = audioClip[0];
        
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Main Menu" || SceneManager.GetActiveScene().name == "StoryStart" || SceneManager.GetActiveScene().name == "controls" || SceneManager.GetActiveScene().name == "GameOver" || SceneManager.GetActiveScene().name == "Win")
        {
            audioSource[0].PlayOneShot(audioSource[0].clip);
        }
        else
        {
            audioSource[0].Stop();
        }
    }
}
