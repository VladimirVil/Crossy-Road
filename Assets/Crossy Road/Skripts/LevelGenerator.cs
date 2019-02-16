using System.Collections;
//will need list to hold preafabs
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour {

    //the current level generation
    public List<GameObject> platform = new List<GameObject>();
    //the height of each platform (Y achse, like the -0.55)
    public List<float> height = new List<float>();

    private int rndRange = 0;
    private float lastPos = 0;
    private float lastScale = 0;
    
    //gonna create the element for us 
    public void RandomGenerator()
    {
        //gonna take all the pieces from the platform( prefabs) and create level object each time based on that 
        rndRange = Random.Range(0, platform.Count);
        for (int i = 0; i<platform.Count; i++)
        {
            CreateLevelObject(platform[i], height[i], i);
        }
    }

    public void CreateLevelObject (GameObject obj, float height, int value)
    {
        // how we set the pieces in:
        if (rndRange == value)
        {
            GameObject go = Instantiate(obj) as GameObject;
            //creating position placing
            float offset = lastPos + (lastScale * 0.5f);
            offset += (go.transform.localScale.z) * 0.5f;
            Vector3 pos = new Vector3(0, height, offset);

            go.transform.position = pos;
            //update of last position values for next object
            lastPos = go.transform.position.z;
            lastScale = go.transform.localScale.z;

            //keeping scene clean
            go.transform.parent = this.transform;
        }
    }

}
