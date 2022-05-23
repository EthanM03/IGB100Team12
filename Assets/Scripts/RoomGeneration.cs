using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoomGeneration : MonoBehaviour
{
    //Room prefabs
    public GameObject deadEnd;
    public int reqIE = 6;
    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemy3;
    public GameObject healthBox;
    //these chances should add to 100
    public int chanceEmpty;
    public int chanceEnemy1;
    public int chanceEnemy2;
    public int chanceEnemy3;
    public int chanceHealthBox;
    public GameObject bossDoor;
    public GameObject lever;
    public GameObject weapon1;
    public GameObject weapon2;
    public GameObject weapon3;

    //Array of rooms created
    public GameObject[] AllRoomTypes;
    public GameObject[] AllRooms = new GameObject[99];
    public int roomsSpawned = 1;

    //Important stuff that can be changed
    public int maxPath = 5;
    public GameObject startingRoom;

    // Start is called before the first frame update
    void Start()
    {
        AllRooms[0] = startingRoom;
        
        //Add rooms
        SpawnChildRooms(startingRoom, null);
        if (roomsSpawned < reqIE)
        {
            SceneManager.LoadScene("MainLevel");
        }
        SpawnIE();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnChildRooms(GameObject root, GameObject filledDoor)
    {
        
        foreach (var door in root.GetComponent<Room>().doors)
        {
            // Is this really a door, and do we need to attach a room to this door?
            if (door != filledDoor && door != null)
            {
                //!!set the location and rotation of the root's door
                Vector3 newRoomLocation = door.transform.position;
                Vector3 newRoomRotation = door.transform.localRotation.eulerAngles + root.transform.rotation.eulerAngles;
                
                bool roomSet = false;
                //if we haven't gone past the max path
                if (root.GetComponent<Room>().pathLength < maxPath)
                {
                    //set the untried room types to the list of all room types
                    GameObject[] untriedRoomTypes = AllRoomTypes;
                   
                    //while loop for until room set
                    while (roomSet == false)
                    {
                        //if we haven't tried all the room types
                        if (untriedRoomTypes.Length > 0)
                        {
                            int roomTypeTry = Random.Range(0, untriedRoomTypes.Length);
                            
                            //try each door until it is nicely set
                            GameObject[] untriedDoors = new GameObject[untriedRoomTypes[roomTypeTry].GetComponent<Room>().doors.Length];
                            //set the doors
                            untriedDoors = untriedRoomTypes[roomTypeTry].GetComponent<Room>().doors;

                            //set door to try

                            while (untriedDoors.Length > 0 && roomSet == false)
                            {
                                int doorTypeTry = Random.Range(0, untriedDoors.Length);

                                //spawn at the position and rotation of the root's door
                                GameObject newRoom =  Instantiate(untriedRoomTypes[roomTypeTry],newRoomLocation, Quaternion.Euler(newRoomRotation));
                                
                                //rotate so the new door is correctly lined up
                                Vector3 newRotation = newRoom.GetComponent<Room>().doors[doorTypeTry].transform.localRotation.eulerAngles;
                                newRotation = new Vector3 (0,newRoomRotation.y + 180.0f - newRotation.y, 0);
                                newRoom.transform.rotation = Quaternion.Euler(newRotation);

                                //find room position - door position
                                Vector3 moveBy = newRoom.GetComponent<Room>().transform.position - newRoom.GetComponent<Room>().doors[doorTypeTry].transform.position;
                                
                                //Account for the thickness of the walls
                                Vector3 wallCorrection = new Vector3 (0,0,0);
                                int wallCorrectionRotation = Mathf.RoundToInt(newRoomRotation.y);
                                wallCorrectionRotation = wallCorrectionRotation % 360;
                                switch (wallCorrectionRotation)
                                {
                                    case 0:
                                        wallCorrection = new Vector3 (1,0,0);
                                        break;
                                    case 90:
                                        wallCorrection = new Vector3 (0,0,-1);
                                        break;
                                    case 180:
                                        wallCorrection = new Vector3 (-1,0,0);
                                        break;
                                    case 270:
                                        wallCorrection = new Vector3 (0,0,1);
                                        break;
                                    default:
                                        break;

                                }
                                //set the new position of the new room
                                newRoom.transform.position = moveBy + newRoomLocation + wallCorrection;


                                //then check that the corners aren't touching
    
                                Vector3[] corners = new Vector3[4];
                                corners[0] = newRoom.GetComponent<Room>().corner1.transform.position;
                                corners[1] = newRoom.GetComponent<Room>().corner2.transform.position;
                                corners[2] = newRoom.GetComponent<Room>().corner3.transform.position;
                                corners[3] = newRoom.GetComponent<Room>().corner4.transform.position;
                                float newxMax = Mathf.Max(corners[0].x, corners[2].x);
                                float newxMin = Mathf.Min(corners[0].x, corners[2].x);
                                float newyMax = Mathf.Max(corners[0].z, corners[2].z);
                                float newyMin = Mathf.Min(corners[0].z, corners[2].z);
                            
                                //overlap false until proved otherwise
                                bool overlap = false;

                                int i = 0;

                                while (overlap == false && AllRooms[i] != null)
                                {
                                    //Debug.Log("Checking for overlaps");
                                    //go through all created rooms and check that it isn't within the corners

                                    //Get corner 1 and 3 location for the room we are checking. Corner 1 and 3 are opposites
                                    Vector3 compareCorner1 = AllRooms[i].GetComponent<Room>().corner1.transform.position;
                                    Vector3 compareCorner3 = AllRooms[i].GetComponent<Room>().corner3.transform.position;

                                    //find the within x value and within y value
                                    float xMax = Mathf.Max(compareCorner1.x, compareCorner3.x);
                                    float xMin = Mathf.Min(compareCorner1.x, compareCorner3.x);
                                    float yMax = Mathf.Max(compareCorner1.z, compareCorner3.z);
                                    float yMin = Mathf.Min(compareCorner1.z, compareCorner3.z);

                                    if ( IsOverlap(xMin, xMax, yMin, yMax, newxMin, newxMax, newyMin, newyMax))
                                    {
                                        //is inside of another room
                                        //Debug.Log("Found overlap");
                                        overlap = true;
                                    }

                                    i += 1;
                                }
                                if (overlap == true)
                                {
                                    //try the next room type
                                    Destroy(newRoom);
                                    //set the next door to try
                                    GameObject[] temp = new GameObject[untriedDoors.Length-1];
                                    for (int a = 0; a < doorTypeTry; a++)
                                    {
                                        //add the first half of untried room types into the temp array
                                        temp[a] = untriedDoors[a];
                                    }
                                    for (int a = doorTypeTry; a <= (untriedDoors.Length -2); a++)
                                    {
                                        //move the second hald into the temp array
                                        temp[a] = untriedDoors[a+1];

                                    }
                                    //set the untried room types to the temp array (smaller length)
                                    untriedDoors = temp;

                                }
                            
                                //no overlap
                                else
                                {
                                    //if you have checked every corner against every room and there is no overlap at all
                                                                        
                                    roomSet = true;
                                    
                                    //add it into the rooms spawned array
                                    int newIndex = roomsSpawned;
                                    AllRooms[newIndex] = newRoom;
                                    //add one to the rooms spawned 
                                    roomsSpawned += 1;
                                    //set the path length to be one bigger than the room it just came from
                                    newRoom.GetComponent<Room>().pathLength = root.GetComponent<Room>().pathLength+1;
                                    
                                    //spawn its children with the room you just used to spawn it in ignored
                                    SpawnChildRooms(newRoom, newRoom.GetComponent<Room>().doors[doorTypeTry]);

                                    //no longer need to check each door to see if it works
                                    break;                                  
                                }
                            }
                            
                            //tried all the doors in that new room and still haven't set it
                            if (roomSet == false)
                            {
                                //remove type tried
                                GameObject[] temp = new GameObject[untriedRoomTypes.Length-1];
                                for (int a = 0; a < roomTypeTry; a++)
                                {
                                    //add the first half of untried room types into the temp array
                                    temp[a] = untriedRoomTypes[a];
                                }
                                for (int a = roomTypeTry; a <= (untriedRoomTypes.Length -2); a++)
                                {
                                    //move the second hald into the temp array
                                    temp[a] = untriedRoomTypes[a+1];

                                }
                                //set the untried room types to the temp array (smaller length)
                                untriedRoomTypes = temp;
                            }

                         
                        }
                        else
                        //have tried to put all room types in -> no luck -> terminate
                        {
                            //set it to a dead end
                                                      
                            Instantiate(deadEnd, newRoomLocation, Quaternion.Euler(newRoomRotation));
                            roomSet = true;  
                        }
                                                               
                    }
                }
                else
                //the path is too long so must terminate
                {
                    //make a dead end
                    Instantiate(deadEnd, newRoomLocation, Quaternion.Euler(newRoomRotation));
                }
            }
            //else don't need to spawn a room for that 'door'
            
            //do all that for the rest of the doors of the room
        }
    }

    public bool IsOverlap(float xMin, float xMax, float yMin, float yMax, float newXMin, float newXMax, float newYMin, float newYMax)
    {
        Rect existingRoom = Rect.MinMaxRect(xMin, yMin, xMax, yMax);
        Rect newRoom = Rect.MinMaxRect(newXMin, newYMin, newXMax, newYMax);
        return newRoom.Overlaps(existingRoom, allowInverse: true);
    }

    public void SpawnIE()
    {
        GameObject[] temp = new GameObject[roomsSpawned-reqIE];
        int bossDoorLocation = Random.Range(1, roomsSpawned-1);
        int lever1Location = Random.Range(1, roomsSpawned-1);
        while (lever1Location == bossDoorLocation)
        {
            lever1Location = Random.Range(1, roomsSpawned-1);
        }
        int lever2Location = Random.Range(1, roomsSpawned-1);
        while (lever2Location == lever1Location || lever2Location == bossDoorLocation)
        {
            lever2Location = Random.Range(1, roomsSpawned-1);
        }
        int weapon1Location = Random.Range(1, roomsSpawned-1);
        while (weapon1Location == lever1Location || weapon1Location == bossDoorLocation || weapon1Location == lever2Location)
        {
            weapon1Location = Random.Range(1, roomsSpawned-1);
        }
        int weapon2Location = Random.Range(1, roomsSpawned-1);
        while (weapon2Location == lever1Location || weapon2Location == bossDoorLocation || weapon2Location == lever2Location || weapon2Location == weapon1Location)
        {
            weapon2Location = Random.Range(1, roomsSpawned-1);
        }
        int weapon3Location = Random.Range(1, roomsSpawned-1);
        while (weapon3Location == lever1Location || weapon3Location == bossDoorLocation || weapon3Location == lever2Location || weapon3Location == weapon1Location || weapon3Location == weapon2Location)
        {
            weapon3Location = Random.Range(1, roomsSpawned-1);
        }
        for (int i = 1; i < roomsSpawned-1; i++)
        {
            if (i == bossDoorLocation)
            {
                AllRooms[i].GetComponent<Room>().IEType = bossDoor;
                Vector3 IEPos = AllRooms[i].GetComponent<Room>().IESpawner.transform.position;
                Quaternion IERot = AllRooms[i].GetComponent<Room>().IESpawner.transform.rotation;
                //instantiate
                GameObject ObjectbossDoor = Instantiate(bossDoor, IEPos, IERot);
            }
            else if (i == lever1Location)
            {
                AllRooms[i].GetComponent<Room>().IEType = lever;
                Vector3 IEPos = AllRooms[i].GetComponent<Room>().IESpawner.transform.position;
                Quaternion IERot = AllRooms[i].GetComponent<Room>().IESpawner.transform.rotation;
                //instantiate
                GameObject objectLever1 = Instantiate(lever, IEPos, IERot);
                //AllRooms[i].GetComponent<Room>.GetComponent<BossDoor>().lever1 = objectLever1;
            }
            else if (i == lever2Location)
            {
                AllRooms[i].GetComponent<Room>().IEType = lever;
                Vector3 IEPos = AllRooms[i].GetComponent<Room>().IESpawner.transform.position;
                Quaternion IERot = AllRooms[i].GetComponent<Room>().IESpawner.transform.rotation;
                //instantiate
                GameObject objectLever2 = Instantiate(lever, IEPos, IERot);
                //ObjectbossDoor.GetComponent<BossDoor>().lever2 = objectLever2;
            }
            else if (i == weapon1Location)
            {
                AllRooms[i].GetComponent<Room>().IEType = weapon1;
                Vector3 IEPos = AllRooms[i].GetComponent<Room>().IESpawner.transform.position;
                Quaternion IERot = AllRooms[i].GetComponent<Room>().IESpawner.transform.rotation;
                //instantiate
                GameObject objectLever2 = Instantiate(weapon1, IEPos, IERot);
            }
            else if (i == weapon2Location)
            {
                AllRooms[i].GetComponent<Room>().IEType = weapon2;
                Vector3 IEPos = AllRooms[i].GetComponent<Room>().IESpawner.transform.position;
                Quaternion IERot = AllRooms[i].GetComponent<Room>().IESpawner.transform.rotation;
                //instantiate
                GameObject objectLever2 = Instantiate(weapon2, IEPos, IERot);
            }
            else if (i == weapon3Location)
            {
                AllRooms[i].GetComponent<Room>().IEType = weapon3;
                Vector3 IEPos = AllRooms[i].GetComponent<Room>().IESpawner.transform.position;
                Quaternion IERot = AllRooms[i].GetComponent<Room>().IESpawner.transform.rotation;
                //instantiate
                GameObject objectLever2 = Instantiate(weapon3, IEPos, IERot);
            }
            else
            {
                //choose whether to spawn anything or not
                float result = Random.Range(0,100);
                if (result <chanceEnemy1)
                {
                    //spawn enemy 1
                    AllRooms[i].GetComponent<Room>().IEType = enemy1;
                    Vector3 IEPos = AllRooms[i].GetComponent<Room>().IESpawner.transform.position;
                    Quaternion IERot = AllRooms[i].GetComponent<Room>().IESpawner.transform.rotation;
                    //instantiate
                    GameObject objectLever2 = Instantiate(enemy1, IEPos, IERot);
                }
                else if (result > chanceEnemy1 && result <chanceEnemy1 + chanceEnemy2)
                {
                    //spawn enemy 2
                    AllRooms[i].GetComponent<Room>().IEType = enemy2;
                    Vector3 IEPos = AllRooms[i].GetComponent<Room>().IESpawner.transform.position;
                    Quaternion IERot = AllRooms[i].GetComponent<Room>().IESpawner.transform.rotation;
                    //instantiate
                    GameObject objectLever2 = Instantiate(enemy2, IEPos, IERot);
                }
                else if (result > chanceEnemy1 + chanceEnemy2 && result <chanceEnemy1 + chanceEnemy2 + chanceEnemy3)
                {
                    //spawn enemy 3
                    AllRooms[i].GetComponent<Room>().IEType = enemy3;
                    Vector3 IEPos = AllRooms[i].GetComponent<Room>().IESpawner.transform.position;
                    Quaternion IERot = AllRooms[i].GetComponent<Room>().IESpawner.transform.rotation;
                    //instantiate
                    GameObject objectLever2 = Instantiate(enemy3, IEPos, IERot);
                }
                else if (result > chanceEnemy1 + chanceEnemy2 + chanceEnemy3 && result <chanceEnemy1 + chanceEnemy2 + chanceEnemy3 + chanceHealthBox)
                {
                    //spawn health box
                    AllRooms[i].GetComponent<Room>().IEType = healthBox;
                    Vector3 IEPos = AllRooms[i].GetComponent<Room>().IESpawner.transform.position;
                    Quaternion IERot = AllRooms[i].GetComponent<Room>().IESpawner.transform.rotation;
                    //instantiate
                    GameObject objectLever2 = Instantiate(healthBox, IEPos, IERot);
                }
                else 
                {
                    //spawn nothing
                    AllRooms[i].GetComponent<Room>().IEType = null;
                }
            }
        }
    }
}
