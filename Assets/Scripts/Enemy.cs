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
    public float damageRate = 0.75f;

    //sound related
    public AudioSource[] audioSource = new AudioSource[1];
    public AudioClip[] audioClip = new AudioClip[1];

    //Effects
    public GameObject deathEffect;

	// Use this for initialization
	void Start () {
        agent = GetComponent<NavMeshAgent>();
        targetingPlayer = false;
        
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

        //sound related
        audioClip[0] = Resources.Load<AudioClip>("Enemy_norm");

        audioSource[0] = this.GetComponent<AudioSource>();

        audioSource[0].clip = audioClip[0];
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
            //GameManager.instance.score +=1;
            //Instantiate(deathEffect, transform.position, transform.rotation);
        }
    }

    private void OnTriggerStay(Collider otherObject) {

        if (otherObject.transform.tag == "Player" && Time.time > damageTime) {
            this.gameObject.GetComponent<Anim>().PlayAnim();
            otherObject.GetComponent<Player>().takeDamage(damage);
            damageTime = Time.time + damageRate;
        }
    }
}
