using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


public class Interactable : MonoBehaviour
{
    public float radius = 3f;
    public bool isInRange;
    public KeyCode interactKey;
    public UnityEvent interactAction;
    public Text interactText;
    

    void Start()
    {
        interactText.text = "";
    }


    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

    void Update()
    {
        if (isInRange)
        {
            if (Input.GetKeyDown(interactKey))
            {
                interactAction.Invoke();
            }
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isInRange = true;
            
            if(GetComponent<Lever>().active == false)
            {
                interactText.text = "'E' to Interact";
            }
            

        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isInRange = false;
            interactText.text = "";

        }
    }

    
}
