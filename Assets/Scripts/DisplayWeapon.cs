using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


public class DisplayWeapon : MonoBehaviour
{
    public float radius = 3f;
    public bool isInRange;
    public Text interactText;
    public GameObject player;
    

    public GameObject swordPrefab;
    public GameObject hammerPrefab;
    public GameObject daggerPrefab;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }


    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

    void Update()
    {
        if (isInRange)
        {
            if (Input.GetKeyDown("e"))
            {
                if (player.GetComponent<Player>().weapon ==1)
                {
                    GameObject newWeapon = Instantiate(daggerPrefab, this.transform.position, this.transform.rotation);
                    newWeapon.GetComponent<DisplayWeapon>().interactText = interactText;
                }
                else if (player.GetComponent<Player>().weapon ==2)
                {
                    GameObject newWeapon = Instantiate(swordPrefab, this.transform.position, this.transform.rotation);
                    newWeapon.GetComponent<DisplayWeapon>().interactText = interactText;
                }
                else if (player.GetComponent<Player>().weapon ==3)
                {
                    GameObject newWeapon = Instantiate(hammerPrefab, this.transform.position, this.transform.rotation);
                    newWeapon.GetComponent<DisplayWeapon>().interactText = interactText;
                }

                if(this.gameObject.CompareTag("Hammer"))
                {
                    interactText.text = "";
                    Destroy(this.gameObject);
                    player.GetComponent<Player>().weapon = 3;
                    GameManager.instance.DisplayStats(false,0);

                }
                if(this.gameObject.CompareTag("Dagger"))
                {
                    interactText.text = "";
                    Destroy(this.gameObject);
                    player.GetComponent<Player>().weapon = 1;
                    GameManager.instance.DisplayStats(false,0);

                }
                if(this.gameObject.CompareTag("Sword"))
                {
                    interactText.text = "";
                    Destroy(this.gameObject);
                    player.GetComponent<Player>().weapon = 2;
                    GameManager.instance.DisplayStats(false,0);
                }
            }
        }
    }

    void OnTriggerEnter(Collider collision)
    {
        if (this.gameObject && collision.gameObject.CompareTag("Player"))
        {
            isInRange = true;
            
            interactText.text = "'E' to Swap";
            if (this.gameObject.CompareTag("Hammer"))
            {
                GameManager.instance.DisplayStats(true,3);
            }
            else if (this.gameObject.CompareTag("Dagger"))
            {
                GameManager.instance.DisplayStats(true,1);
            }
            else if (this.gameObject.CompareTag("Sword"))
            {
                GameManager.instance.DisplayStats(true,2);
            }
  
        }
            

    }
    

    void OnTriggerExit(Collider collision)
    {
        if (this.gameObject && collision.gameObject.CompareTag("Player"))
        {
            isInRange = false;
            interactText.text = "";
            GameManager.instance.DisplayStats(false,0);

        }
    }

    
}
