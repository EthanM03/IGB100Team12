using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    //corner 1 and 3 must be diagonal from each other
    public Vector3 corner1;
    public Vector3 corner2;
    public Vector3 corner3;

    public Vector3 entryDoorLocation;
    public Vector3 doorLocation1;
    public Vector3 doorLocation2;
    public Vector3 doorLocation3;

    public Vector3[] doorLocations;

    //Must Haves
    public GameObject IEType;
    public GameObject parent;
    public GameObject[] children;
    //(for now)
    public int index;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
