using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class win_screen_temp : MonoBehaviour
{
    public GameObject win_screen;
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            win_screen.SetActive(true);
            Destroy(this.gameObject);
        }
    }
}

