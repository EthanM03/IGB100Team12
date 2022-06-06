using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DoorConroller : MonoBehaviour
{
    public GameObject Lever_1;
    public GameObject Lever_2;
    public bool port_SFX;
    public GameObject port;
    public bool portal_Active;
    public Text nportalText;
    public bool collisionP = false;
    public GameObject child;
    // Start is called before the first frame update
    void Start()
    {
       port.SetActive(false);
       if(child != null)
       {
           child.GetComponent<DoorConroller>().Lever_1 = Lever_1;
           child.GetComponent<DoorConroller>().Lever_2 = Lever_2;
           child.GetComponent<DoorConroller>().nportalText = nportalText;
       }
    }

    // Update is called once per frame
    void Update()
    {
        if (Lever_1.GetComponent<Lever>().active == true && Lever_2.GetComponent<Lever>().active == true)
        {
            port.SetActive(true);
            port_SFX = true;
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

    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            portal_Active = true;
            collisionP = true;
            // Debug.Log("collision");

        }
    }

    private void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            
            // Debug.Log("stay");
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            portal_Active = false;
            collisionP = false;
            // Debug.Log("un-collision");
        }
    }
}
