using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour {
    //possible directions setting
    public bool goLeft = false;
    public bool goRight = false;
    //list of game objects, like the cars on the road, that are used for spawning 
    public List<GameObject> items = new List<GameObject>();
    public List<Spawner> spawnersLeft = new List<Spawner>();
    public List<Spawner> spawnersRight = new List<Spawner>();

    private void Start()
    {
        //gonna set up all the spawners at the beginning
        int itemId = Random.Range(0, items.Count);
        //Grabing an obket and storing it inside item
        GameObject item = items[itemId];
        int direction = Random.Range(0, 2);

        //if direction bigger then zero, we go right
        if (direction > 0) { goLeft = false; goRight = true; } else { goLeft = true; goRight = false; } 

        for(int i=0; i<spawnersLeft.Count; i++)
        {
            //setting spawner properties
            //assign the object 
            spawnersLeft[i].item = item;
            //setting goleft, to know which direction
            spawnersLeft[i].goLeft = goLeft;
            //setting goRight as well
            spawnersLeft[i].gameObject.SetActive(goRight);
            //grabing the left position from spawners actual left position 
            spawnersLeft[i].spawnLeftPos = spawnersLeft[i].transform.position.x;
        }

        for (int i = 0; i < spawnersRight.Count; i++)
        {
            //setting spawner properties
            //assign the object 
            spawnersRight[i].item = item;
            //setting goleft, to know which direction
            spawnersRight[i].goLeft = goLeft;
            //setting goRight as well
            spawnersRight[i].gameObject.SetActive(goRight);
            //grabing the left position from spawners actual left position 
            spawnersRight[i].spawnRightPos = spawnersRight[i].transform.position.x;
        }

    }


}
