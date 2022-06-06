using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    public bool active = false;

    public AudioSource[] audioSource = new AudioSource[1];
    public AudioClip[] audioClip = new AudioClip[1];
    
    //public GameObject thisLever; 



    // Start is called before the first frame update
    void Start()
    {

        audioClip[0] = Resources.Load<AudioClip>("LeverSound");        

        audioSource[0] = this.GetComponent<AudioSource>();

        audioSource[0].clip = audioClip[0];
    }

    // Update is called once per frame
    void Update()
    {
        
   
    }

    public void Interact()
    {
        if (!active)
        {
            GetComponent<Animation>().Play("LeverActive");
            audioSource[0].Play();
        }
        active = true;
        
        Debug.Log("active");
       
    }
}
