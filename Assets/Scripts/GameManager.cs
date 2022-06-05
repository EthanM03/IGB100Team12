using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    //Singleton Setup
    public static GameManager instance = null;

    public float time;
    public float maxTime = 15;

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

        //GameConditions();

        //UpdateUI();
        //CheckInput();
	}
    // private void CheckInput()
    // {
    //     if (Input.GetKey("backspace") && Input.GetKey("left shift"))
    //     {
    //         SceneManager.LoadScene(0);
    //     }
    // }

    // private void GameConditions()
    // {
    //     if (!player)
    //     {
    //         gameOver = true;
    //         dead = true;
    //     }
    //     else if (time > maxTime && enemies.Length==0)
    //     {
    //         gameOver = true;
    //     }

    //     //Update scores
    //     if (gameOver)
    //     {
    //         if(score > PlayerPrefs.GetInt("HighScore", 0))
    //         {
    //             PlayerPrefs.SetInt("HighScore", score);
    //         }
    //     }
    // }

    // private void UpdateUI()
    // {
    //     //Enemies
    //     enemiesRemaning.text = "Enemies Remaining: " + enemies.Length;

    //     //time 
    //     if (time < maxTime)
    //     {
    //        timeRemaining.text = "Time Remaining: " + (int)(maxTime-time); 
    //     }
        
    //     //score
    //     scoreText.text = "Score: " + score;

    //     //endgame text
    //     if (gameOver && dead)
    //     {
    //         gameOverText.text = "You are dead";
    //     }
    //     else if (gameOver)
    //     {
    //         gameOverText.text = "You Win!";
    //     }
    // }
    public void DisplayStats(bool active, int i)
    {
        Debug.Log(active);
        int j = player.GetComponent<Player>().weapon;
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
}
