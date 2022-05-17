using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door_win : MonoBehaviour
{
    public GameObject door_red;
    public GameObject door_green;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            door_red.SetActive(false);
            Destroy(this.gameObject);
        }

        if (other.transform.tag == "Player")
        {
            door_green.SetActive(true);
            Destroy(this.gameObject);
        }
    }
}
