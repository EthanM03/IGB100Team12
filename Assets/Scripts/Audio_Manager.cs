using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio_Manager : MonoBehaviour
{

    public AudioSource[] audioSource = new AudioSource[2];
    public AudioClip[] audioClip = new AudioClip[2];
    public GameObject portal;
    public GameObject FPS;

    //spublic static Audio_Manager instance; 


    private void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        //scene_Start_Sounds();

        Invoke("scene_Start_Sounds", 1f);
    }

    
    // Update is called once per frame
    void Update()
    {
        Invoke("play_Portal", 1f);
    }

    

    void play_Portal()
    {
        if (portal.GetComponent<DoorConroller>().port_SFX == true)
        {
            audioSource[0].PlayOneShot(audioSource[0].clip);
            Debug.Log("sounds");
        }
        else
        {
            audioSource[0].Stop();
        }
    }

    public void scene_Start_Sounds()
    {
        audioClip[0] = Resources.Load<AudioClip>("Portal_loop");
        audioClip[1] = Resources.Load<AudioClip>("Main_Game");

        FPS = GameObject.Find("FirstPersonCharacter");

        audioSource[0] = portal.GetComponent<AudioSource>();
        audioSource[1] = FPS.GetComponent<AudioSource>();   
        

        audioSource[0].clip = audioClip[0];
        audioSource[1].clip = audioClip[1];
        

        audioSource[1].PlayOneShot(audioSource[1].clip);
    }
   
}
