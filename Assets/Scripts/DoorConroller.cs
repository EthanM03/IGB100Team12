using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DoorConroller : MonoBehaviour
{
    public GameObject Lever_1;
    public GameObject Lever_2;
    public bool port_VFX;
    public GameObject port;
    public bool portal_Active;
    public Text nportalText;
    public bool collisionP = false;

    //Sounds related
   /* public AudioSource[] audioSource = new AudioSource[1];
    public AudioClip[] audioClip = new AudioClip[1];
    public GameObject portal;*/
    // Start is called before the first frame update
    void Start()
    {
       port.SetActive(false);

        //sound related
       /* audioClip[0] = Resources.Load<AudioClip>("Portal_loop");

        portal = GameObject.Find("PortalCollider");
        audioSource[0] = portal.GetComponent<AudioSource>();

        audioSource[0].clip = audioClip[0];
        */
    }

    // Update is called once per frame
    void Update()
    {
        if (Lever_1.GetComponent<Lever>().active == true && Lever_2.GetComponent<Lever>().active == true)
        {
            port.SetActive(true);
            port_VFX = true;            
        }

        if (collisionP && (!Lever_1.GetComponent<Lever>().active || !Lever_2.GetComponent<Lever>().active))
        {
            nportalText.text = "Portal Not Activated";
        }
        else
        {
            nportalText.text = "";
        }
        
        if (Lever_1.GetComponent<Lever>().active == true && Lever_2.GetComponent<Lever>().active == true && portal_Active == true)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

       /* if (port_VFX == true)
        {
            audioSource[0].Play();
        }*/

    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            portal_Active = true;
            collisionP = true;
            Debug.Log("collision");

        }
    }

  

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            portal_Active = false;
            collisionP = false;
            Debug.Log("un-collision");
        }
    }
}
