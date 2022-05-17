using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeapon : MonoBehaviour
{
    Animation animation;
    public float damage = 10.0f;
    public float hitRate = 0.4f;
    private float hitTime;

    // Start is called before the first frame update
    void Start()
    {
        animation = GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    //!! fix this
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy" )
        {
            other.GetComponent<Enemy>().takeDamage(damage);
        }
    }
}
