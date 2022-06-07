using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Music : MonoBehaviour
{

    public AudioSource[] audioSource = new AudioSource[1];
    public AudioClip[] audioClip = new AudioClip[1];

    public GameObject FPS;
    // Start is called before the first frame update
    void Start()
    {
        audioClip[0] = Resources.Load<AudioClip>("boss_Music");        

        FPS = GameObject.Find("FirstPersonCharacter");
        
        audioSource[0] = FPS.GetComponent<AudioSource>();

        audioSource[0].clip = audioClip[0];

        audioSource[0].Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
