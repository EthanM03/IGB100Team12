using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomGenerator : MonoBehaviour
{
    //Room prefabs
    public GameObject roomType1;
    public GameObject[] IETypes;

    //Array of rooms created
    public int numRoomTypes;
    public GameObject[] AllRoomTypes;
    public List<GameObject> AllRooms;

    //Important stuff that can be changed
    public int maxPath = 5;
    public int pathLength = 0;

    // Start is called before the first frame update
    void Start()
    {
        //!!spawn first room
        GameObject startingRoom;
        //^^Add to array as root

        //Set array of all roomTypes
        AllRoomTypes = GameObject.FindGameObjectsWithTag("Room");
        numRoomTypes = AllRoomTypes.Length;

        //Add rooms
        //SpawnChildRooms(startingRoom);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnChildRooms(GameObject root)
    {
        foreach (var door in root.GetComponent<Room>().doorLocations)
        {
            //!!set the location of the door
            bool roomSet = false;
            if (pathLength > maxPath)
            {
                GameObject[] untriedRoomTypes = AllRoomTypes;
                //while loop for until room set
                while (roomSet == false)
                {
                    if (untriedRoomTypes.Length > 0)
                    {
                       int roomTypeTry = Random.Range(0, untriedRoomTypes.Length);
                       
                       //spawn the room in

                       //if the corners are within any of the rooms that already exists c1-c2 or c1-c3 --> make sure to account for wall thickness
                            //remove untriedRoomTypes[roomTypeTry]
                            //destroy the room spawned in
                        //else
                            //isSet is true
                            //add it to the list of rooms
                            //move onto -> either its first child or its sibling??
                                //i think it would be good to do this as a stack or queue
                    }
                    else
                    {
                        //set it to a dead end
                    }
                    

               
                }
            }
            else
            {
                //make a dead end
            }

            
        }
    }
}
