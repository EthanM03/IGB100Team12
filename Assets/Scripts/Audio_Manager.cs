using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio_Manager : MonoBehaviour
{

    public AudioSource[] audioSource = new AudioSource[2];
    public AudioClip[] audioClip = new AudioClip[2];
    public GameObject portal;
    public GameObject FPS;

    public static Audio_Manager instance; 


    private void Awake()
    {
        if (instance == null)
        {
            instance = this; 
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject); 
    }

    // Start is called before the first frame update
    void Start()
    {
        audioClip[0] = Resources.Load<AudioClip>("Portal_loop");
        audioClip[1] = Resources.Load<AudioClip>("Main_Game");

        portal = GameObject.Find("PortalCollider");
        FPS = GameObject.Find("FPSController");
    
        audioSource[0] = portal.GetComponent<AudioSource>();
        audioSource[1] = FPS.GetComponent<AudioSource>();

        audioSource[0].clip = audioClip[0];
        audioSource[1].clip = audioClip[1];
        
        audioSource[1].PlayOneShot(audioSource[1].clip); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        play_Portal();
    }

    void play_Portal()
    {
        if (portal.GetComponent<DoorConroller>().port_VFX == true)
        {
            audioSource[0].PlayOneShot(audioSource[0].clip);
            Debug.Log("sounds");
        }
    }
   
}
