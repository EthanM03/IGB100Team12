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
    public GameObject IEType;
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
        
    }
}
