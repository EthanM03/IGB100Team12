using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    //corner 1 and 3 must be diagonal from each other
    public GameObject corner1;
    public GameObject corner2;
    public GameObject corner3;
    public GameObject corner4;


    //Must Haves
    public GameObject IE = null;
    public GameObject IESpawner;

    public GameObject[] doors;

    public int pathLength;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateEnemyTarget();
    }

    private void UpdateEnemyTarget()
    {
        if (IE != null && IE.GetComponent<Enemy>() != null)
        {
            //Debug.Log("Enemy in room");
            
            
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player)
            {
                //set the bounds of the rooms
                float xMax = Mathf.Max(corner1.transform.position.x,corner3.transform.position.x);
                float xMin = Mathf.Min(corner1.transform.position.x,corner3.transform.position.x);
                float zMax = Mathf.Max(corner1.transform.position.z,corner3.transform.position.z);
                float zMin = Mathf.Min(corner1.transform.position.z,corner3.transform.position.z);

                if (player.transform.position.x >= xMin && player.transform.position.x <= xMax && player.transform.position.z >= zMin && player.transform.position.z <= zMax)
                {
                    //player is in room
                    //Debug.Log("Player in room");
                    if (IE.GetComponent<Enemy>().targetingPlayer == false)
                    {
                        IE.GetComponent<Enemy>().targetingPlayer = true;
                    }
                    
                }
                else
                {
                    //Debug.Log("Player not in room");
                    //player not in the room
                    if (IE.GetComponent<Enemy>().targetingPlayer == true)
                    {
                        IE.GetComponent<Enemy>().targetingPlayer = false;
                    }
                }
            }
        }
        

    }
}
