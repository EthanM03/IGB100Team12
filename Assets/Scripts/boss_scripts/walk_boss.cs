using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class walk_boss : MonoBehaviour
{
    public float movespeed = 15.0f;

    public GameObject Target;
    NavMeshAgent nav;


    public float alive;
    public int damage = 50;
    //private float damagerate = 0.2f;
    //private float damagetime;

    public float health = 100.0f;
    public GameObject deathFX;
    //public GameObject deadbody;

    public GameObject projectile;
    public float firerate = 0.15f;
    private float firetime;
    public float spawnRate = 2.0f;
    private float spawnTimer;
    public Slider healthbar;
    // Start is called before the first frame update

    private void SpawnEnemy()
    {
        if (Target.transform.position.z > -40 &&  Time.time > spawnTimer)
        {
            Instantiate(projectile, transform.position, transform.rotation);
            spawnTimer = Time.time + spawnRate;
        }
    }


    void Start()
    {
        healthbar.value = health/health;
        nav = GetComponent<NavMeshAgent>();
        Target = GameObject.FindWithTag("Player");

        //firerate = 1f;
        //firetime = Time.time;
    }



    // Update is called once per frame
    void Update()
    {
        nav.SetDestination(Target.transform.position + new Vector3(0.0f,1.5f,0.0f));
        SpawnEnemy();
        //CheckIfTimeToShoot();

    }
    public void TakeDamage(float damage)
    {
        health -= damage;
        healthbar.value = health/500.0f;
        if (health <= 0)
        {
            SceneManager.LoadScene("Win");
            // Destroy(this.gameObject);

        }
    }

}