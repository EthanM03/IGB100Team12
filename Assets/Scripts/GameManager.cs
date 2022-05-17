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
    public Text enemiesRemaning;
    public Text timeRemaining;
    public Text scoreText;
    public Text gameOverText;

    //Game elements
    public GameObject[] enemies;
    public int score = 0;
    public bool gameOver = false;
    public bool dead = false;


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
        //player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
        //time += Time.deltaTime;

        //enemies = GameObject.FindGameObjectsWithTag("Enemy");

        //GameConditions();

        //UpdateUI();
        CheckInput();
	}
    private void CheckInput()
    {
        if (Input.GetKey("backspace") && Input.GetKey("left shift"))
        {
            SceneManager.LoadScene(0);
        }
    }

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
}
