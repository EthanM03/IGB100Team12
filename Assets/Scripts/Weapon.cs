using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    Animation animation;

    //danage variables
    public float damage = 10.0f;
    public float fireRate = 0.51f;
    private float fireTime;

    //Spawn Effects and Target Objects
    public GameObject muzzleFlash;
    public GameObject bulletHit;
    public GameObject muzzle;
    public GameObject target;

    //Ausio Effect
    public GameObject fireSound;

    // Start is called before the first frame update
    void Start()
    {
        animation = GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        WeaponFiring();
    }

    private void WeaponFiring()
    {
        if (Input.GetMouseButton(0) && Time.time > fireTime)
        {
            //spawn effects
            Instantiate(fireSound, transform.position, transform.rotation);
            Instantiate(muzzleFlash, muzzle.transform.position, muzzle.transform.rotation);
            animation.Play("Fire");

            //raycast projectile
            RaycastHit hit;
            if(Physics.Raycast(muzzle.transform.position, -(muzzle.transform.position-target.transform.position).normalized, out hit, 50.0f))
            {
                //Damage Enemies
                if(hit.transform.tag == "Enemy")
                {
                    hit.transform.GetComponent<Enemy>().takeDamage(damage);
                }
                Instantiate(bulletHit, hit.transform.position, hit.transform.rotation);
            }

            //Increase next fire time
            fireTime = Time.time + fireRate;
        }
    }
}
