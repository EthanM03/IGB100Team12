using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyShooter : MonoBehaviour
{
    //public float movespeed = 15.0f;

    //public Transform Target;
    //NavMeshAgent nav;


    //public float alive;
    public int damage = 50;
    //private float damagerate = 0.2f;
    private float damagetime;

    //public float health = 100.0f;
    //public GameObject deathFX;
    //public GameObject deadbody;

    public GameObject projectile;
    public float firerate = 0.15f;
 
    public float spawnRate = 2.0f;
    private float spawnTimer;
    // Start is called before the first frame update

    private void SpawnEnemy()
    {
        if (Time.time > spawnTimer)
        {
            Instantiate(projectile, transform.position, transform.rotation);
            spawnTimer = Time.time + spawnRate;
        }
    }

    //void OnTriggerEnter(Collider other)
    //{
    //    if (other.tag == "player")
    //    {

    //    }
    //}

    void Start()
    {
        //nav = GetComponent<NavMeshAgent>();
        //Target = GameObject.FindWithTag("Player").transform;

        //firerate = 1f;
        //firetime = Time.time;
    }



    ////// Update is called once per frame
    //void Update()
    //{
    //    nav.SetDestination(Target.position);
    //    SpawnEnemy();
    //    //CheckIfTimeToShoot();

    //}

}