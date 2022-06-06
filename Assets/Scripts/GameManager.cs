using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    //Singleton Setup
    public static GameManager instance = null;

    // public float time;
    // public float maxTime = 15;
    public GameObject gameOverPannel;
    public bool gameOver;
    public bool dead;
    public GameObject player;
   

    //UI Elements
    
    public Text currentName;
    public Text currentSpeed;
    public Text currentDamage;
    public Text weaponName;
    public Text weaponSpeed;
    public Text weaponDamage;
    //Game elements
    

    // Awake Checks - Singleton setup
    void Awake() {

        //Check if instance already exists
        if (instance == null)

            //if not, set instance to this
            instance = this;

        //If instance already exists and it's not this:
        else if (instance != this)
            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);
    }

    // Use this for initialization
    void Start () {
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            PlayerPrefs.SetInt("CurrentWeapon", 1);
        }
        
        gameOverPannel.SetActive(false);
        dead = false;
        gameOver = false;
        player = GameObject.FindGameObjectWithTag("Player");
        currentName.gameObject.SetActive(false);
        currentSpeed.gameObject.SetActive(false);
        currentDamage.gameObject.SetActive(false);
        weaponName.gameObject.SetActive(false);
        weaponSpeed.gameObject.SetActive(false);
        weaponDamage.gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        //time += Time.deltaTime;

        //enemies = GameObject.FindGameObjectsWithTag("Enemy");
        PlayerPrefs.SetInt("CurrentWeapon", player.GetComponent<Player>().weapon) ;
        // Debug.Log(PlayerPrefs.GetInt("CurrentWeapon"));

        GameConditions();

        UpdateUI();
        //CheckInput();
	}

    private void GameConditions()
    {
        if (!player)
        {
            gameOver = true;
            dead = true;
        }
    }

    private void UpdateUI()
    {
        //endgame text
        if (gameOver && dead)
        {
            //gameOverPannel.SetActive(true);
        }
        else if (gameOver)
        {
            //gameOverPannel.SetActive(true);
        }
    }
    public void DisplayStats(bool active, int i)
    {
        
        int j = player.GetComponent<Player>().weapon;
        // Debug.Log(i.ToString() + " " + j.ToString());
        if (active)
        {
            currentName.gameObject.SetActive(true);
            currentSpeed.gameObject.SetActive(true);
            currentDamage.gameObject.SetActive(true);
            weaponName.gameObject.SetActive(true);
            weaponSpeed.gameObject.SetActive(true);
            weaponDamage.gameObject.SetActive(true);
        }
        if (active == false)
        {
            currentName.gameObject.SetActive(false);
            currentSpeed.gameObject.SetActive(false);
            currentDamage.gameObject.SetActive(false);
            weaponName.gameObject.SetActive(false);
            weaponSpeed.gameObject.SetActive(false);
            weaponDamage.gameObject.SetActive(false);
        }
        
        if (i ==1)
        {
            weaponName.text = "Dagger";
            weaponSpeed.text = "Speed: Fast";
            weaponDamage.text = "Damage: 10";
        }
        else if (i==2)
        {
    
            weaponName.text = "Sword";
            weaponSpeed.text = "Speed: Medium";
            weaponDamage.text = "Damage: 25";
        }
        else if (i==3)
        {
            weaponName.text = "Hammer";
            weaponSpeed.text = "Speed: Slow";
            instance.weaponDamage.text = "Damage: 50";      
        }
        if (active&&j==1)
        {
            currentName.text = "Dagger";
            currentSpeed.text = "Speed: Fast";
            currentDamage.text = "Damage: 10";
        }
        else if (active&&j == 2)
        {
            currentName.text = "Sword";
            currentSpeed.text = "Speed: Medium";
            currentDamage.text = "Damage: 25";
        }
        else if (active&&j==3)
        {
            currentName.text = "Hammer";
            currentSpeed.text = "Speed: Slow";
            currentDamage.text = "Damage: 50";
        }
    }
    public void Win()
    {
        gameOver = true;
    }
}
