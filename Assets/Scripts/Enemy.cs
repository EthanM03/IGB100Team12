using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    NavMeshAgent agent;
    public GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        //player reference exception 
        try
        {
            target = GameObject.FindGameObjectWithTag("Player");
        }
        catch 
        {
            
            target = null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }
    private void Movement()
    {
        if (target)
        {
            agent.destination = target.transform.position;
        }
    }
}
