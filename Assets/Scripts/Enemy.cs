using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour {

    NavMeshAgent agent;

    public float health = 100;

    public GameObject Playertarget;
    public GameObject deadPrefab;

    public GameObject Spawnertarget;
    public bool targetingPlayer;

    private float damage = 10;
    private float damageTime;
    public float damageRate = 0.75f;

    //sound related
    public AudioSource[] audioSource = new AudioSource[2];
    public AudioClip[] audioClip = new AudioClip[2];

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
        audioClip[1] = Resources.Load<AudioClip>("enemy_Damage");

        audioSource[0] = this.GetComponent<AudioSource>();

        audioSource[1] = gameObject.AddComponent<AudioSource>();
        audioSource[1].volume = 0.1f;
        audioSource[1].spatialBlend = 1;

        audioSource[0].clip = audioClip[0];
        audioSource[1].clip = audioClip[1];

        audioSource[0].PlayOneShot(audioSource[0].clip);
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

        if (!audioSource[1].isPlaying)
        {
            audioSource[1].Play();
        }
        

        if (health <= 0) {
            if (deadPrefab != null)
            {
                Instantiate(deadPrefab, transform.position, transform.rotation);
            }
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


