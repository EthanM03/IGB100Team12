using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    public float health = 100;
    private float maxHealth;
    public GameObject weapon;
    public float healthRestore = 10;

    public GameObject mainCamera;
    public float reach = 20.0f;

    //UI Elements
    public Slider healthbar;

	// Use this for initialization
	void Start () {
        maxHealth = health;
        weapon = null;
	}
	
	// Update is called once per frame
	void Update () 
    {

	}

    public void takeDamage(float dmg) {
        health -= dmg;

        healthbar.value = (health / maxHealth);

        if (health <= 0) {
            mainCamera.SetActive(true);
            Destroy(this.gameObject);
        }
    }

    public void interact()
    {
        //find what the player is looking at
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, reach))
        {
            if(hit.transform.tag == "Weapon")
            {
                hit.transform.GetComponent<MeleeWeapon>().potentialSwap();
            }
            if (hit.transform.tag == "Lever")
            {
                //lever stuff here
            }
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Health")
        {
            if (health < (100-healthRestore))
            {
                health += healthRestore;
                Destroy(other.gameObject);
            }
            else if (health < 100)
            {
                health = 100;
                Destroy(other.gameObject);
            }
            
            healthbar.value = (health / maxHealth);
        }
    }

}
