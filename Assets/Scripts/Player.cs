using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

    public float health = 100;
    private float maxHealth;
    public float healthRestore = 10;

    public GameObject mainCamera;
    public float reach = 20.0f;

    //UI Elements
    public Slider healthbar;
    public int weapon;
    public GameObject sword;
    public GameObject dagger;
    public GameObject hammer;

	// Use this for initialization
	void Start () {
        maxHealth = health;
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            weapon = PlayerPrefs.GetInt("CurrentWeapon");
        }
        else
        {
          weapon = 1;  
        }
        
	}
	
	// Update is called once per frame
	void Update () 
    {
        CheckWeapon();
	}

    public void takeDamage(float dmg) {
        health -= dmg;

        healthbar.value = (health / maxHealth);

        if (health <= 0) {
            // mainCamera.SetActive(true);
            SceneManager.LoadScene("GameOver");
            // Destroy(this.gameObject);
            
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

    public void CheckWeapon()
    {
        if (weapon ==1)
        {
            dagger.SetActive(true);
            sword.SetActive(false);
            hammer.SetActive(false);
        }
        if (weapon ==2)
        {
            dagger.SetActive(false);
            sword.SetActive(true);
            hammer.SetActive(false);
        }
        if (weapon ==3)
        {
            dagger.SetActive(false);
            sword.SetActive(false);
            hammer.SetActive(true);
        }
    }

}
