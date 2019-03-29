using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public Transform startPos = null;
    //spawn time based
    public float delayMin = 1.5f;
    public float delayMax = 5f;
    public float speedMin = 1f;
    public float speedMax = 5f;

    //spawn at start
    public bool useSPawnPlacement = false;
    public int spawnCountMin = 4;
    public int spawnCountMax = 20;

    private float lastTime = 0;
    private float delayTime = 0;
    private float speed = 0;

    [HideInInspector] public GameObject item = null;
    //if not left, then it is right
    [HideInInspector] public bool goLeft = false;
    [HideInInspector] public float spawnLeftPos = 0;
    [HideInInspector] public float spawnRightPos = 0;

     void Start()
    {

        if (useSPawnPlacement)
        {
            //calculating spawn count randomly from our set range 
            int spawnCount = Random.Range(spawnCountMin, spawnCountMax);
            //loop to spawn the objects. Because random is totally random, can happen that more objects will be created in the same point 
            for (int i =0; i<spawnCount;i++)
            {
                SpawnItem();
            }
        }
        else
        {
            speed = Random.Range(speedMin, speedMax);
        }
        
    }

     void Update()
    {
        //we don't wanna run the placement forever 
        if (useSPawnPlacement) return;

        //if there was no new item for long enough, then we spasn a new item(and updating the time values)
        if(Time.time > lastTime + delayTime)
        {
            //calculating new time and delay
            lastTime = Time.time;
            delayTime = Random.Range(delayMin, delayMax);
            SpawnItem();
        }
    }

    void SpawnItem()
    {
        //gonna take a game object and set its postion/direction
        GameObject obj = Instantiate(item) as GameObject;
        obj.transform.position = GetSpawnPosition();
        //should pay attention which direction the spawned object should move
        //0 to go right, 180 to go left 
        float direction = 0;
        if (goLeft) direction = 180;

        if (!useSPawnPlacement)
        {
            obj.GetComponent<Mover>().speed = speed;
            //sets proper direction to the new object
            obj.transform.rotation = obj.transform.rotation * Quaternion.Euler(0, direction, 0);

        }

    }

    Vector3 GetSpawnPosition()
    {
        if (useSPawnPlacement)
        {
            //return a new position for the spawn which is a random between the two edges
            return new Vector3(Random.Range(spawnLeftPos, spawnRightPos), startPos.position.y, startPos.position.z);

        }
        else
        {
            //if no interess to use the placer, the start position will be choosen
            return startPos.position;
        }
    }
}
