using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBullet : MonoBehaviour
{
    public int damage = 50;
    public float moveSpeed = 15.0f;
    //private float damagerate = 0.2f;
    private float damagetime;
    public float lifetime = 2.0f;
    public GameObject deathFX;
    void Start()
    {
        Destroy(this.gameObject, lifetime);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.transform.tag == "Player" && Time.time > damagetime)
        {
            other.transform.GetComponent<Player>().takeDamage(damage);
            damagetime = Time.time + damagetime;
            Destroy(this.gameObject);
            //other.transform.GetComponent<frendlyUnit>().takedamage(damage);
            //damagetime = Time.time + damagetime;
            //Destroy(this.gameObject);
        }

    }
    void Update()
    {
        Movement();
    }

    private void Movement()
    {
        transform.position += Time.deltaTime * moveSpeed * transform.forward;
    }

}
