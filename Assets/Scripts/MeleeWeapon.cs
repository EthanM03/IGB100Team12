using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeapon : MonoBehaviour
{
    Animation animation;
    public float damage = 10.0f;
    public float hitRate = 0.4f;
    public float hitTime;
    public bool isActive = false;

    // Start is called before the first frame update
    void Start()
    {
        animation = GetComponent<Animation>();
        isActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        isAttacking();
    }
    
    //!! fix this
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy" && isAttacking())
        {
            other.GetComponent<Enemy>().takeDamage(damage);
        }
    }
    
    private bool isAttacking()
    {
        if(Input.GetMouseButton(0) && Time.time > hitTime)
        {
            Debug.Log("hit");
            animation.Play();

           

            hitTime = Time.time + hitRate;
            return true;
        }
        else{
            return false;
        }
    }

    public void potentialSwap()
    {
        //display info about the weapon
        
        //if the player presses E then swap
    }
}
