using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lookat : MonoBehaviour
{
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (player)
        {
           transform.LookAt(player.transform); 
        }

        

        //transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, 0f, 0f);
    }
}
