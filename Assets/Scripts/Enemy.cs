using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour {

    NavMeshAgent agent;

    public float health = 100;

    public GameObject Playertarget;

    public GameObject Spawnertarget;
    public bool targetingPlayer;

    private float damage = 10;
    private float damageTime;
    private float damageRate = 0.5f;

    //Effects
    public GameObject deathEffect;

	// Use this for initialization
	void Start () {
        agent = GetComponent<NavMeshAgent>();
        //targetingPlayer = false;
        
        //player reference exception catch
        try
        {
            //this will be the bit where you have to change the target
            Playertarget = GameObject.FindGameObjectWithTag("Player");
        }
        catch 
        {
            
            Playertarget = null;
        }
    }
	
	// Update is called once per frame
	void Update () {
        
        Movement();
        
	}

    

    private void Movement()
    {
        if (Playertarget && targetingPlayer)
        {
            agent.destination = Playertarget.transform.position;
        }
        else
        {
            agent.destination = Spawnertarget.transform.position;
        }
    }

    //Public method for taking damage and dying
    public void takeDamage(float dmg) {
        health -= dmg;

        if (health <= 0) {
            Destroy(this.gameObject);
            GameManager.instance.score +=1;
            Instantiate(deathEffect, transform.position, transform.rotation);
        }
    }

    private void OnTriggerStay(Collider otherObject) {

        if (otherObject.transform.tag == "Player" && Time.time > damageTime) {
            otherObject.GetComponent<Player>().takeDamage(damage);
            damageTime = Time.time + damageRate;
        }
    }
}
