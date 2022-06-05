using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MeleeWeapon : MonoBehaviour
{
    Animation animation;
    public float damage = 10.0f;
    public float hitRate = 0.4f;
    public float hitTime;
    public bool isActive = false;
    private bool attacking = false;

    // Start is called before the first frame update
    void Start()
    {
        
        animation = gameObject.GetComponent<Animation>();
        isActive = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        isAttacking();
        //Debug.Log(attacking);
    }
    
    //!! fix this
    void OnTriggerStay(Collider other)
    {
        //Debug.Log(attacking);
        if (other.tag == "Enemy" && attacking)
        {
            Debug.Log("hit");
            other.GetComponent<Enemy>().takeDamage(damage);
        }
    }
    
    private void isAttacking()
    {
        if(Input.GetMouseButton(0) && Time.time > hitTime)
        {
            
            animation.Play();
            attacking = true;

            hitTime = Time.time + hitRate;
           
        }
        else if (Time.time<hitTime)
        {
            attacking = false;
        }
    }

    
}
