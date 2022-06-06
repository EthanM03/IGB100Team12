using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    public bool active = false;

    //public GameObject thisLever; 

    
    // Start is called before the first frame update
    void Start()
    {
       
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
        }
        active = true;
        
        //Debug.Log("active");
       
    }
}
