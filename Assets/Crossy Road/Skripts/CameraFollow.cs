/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    //Camera moves but  doesn't follow properly the player. Need to debug    
    public float speed = 0.2f;
    public bool autoMove = true;
    public GameObject player = null;
    //camera location
    //public Vector3 offset = new Vector3(3, 6, -3);
    public Vector3 offset = new Vector3(-0.5f, 4, -0.8f);  // offset between player and camera object
   // public Vector3 offset = new Vector3(26, 26, 0);

    Vector3 depth = Vector3.zero;   //how high the camera is 
    Vector3 pos = Vector3.zero;

    void Update()
   // void LateUpdate()
        {
        if (!Manager.instance.CanPlay()) return;

        if (autoMove)
        {
            //depth - how high is the camera located    
            //camera should go forward with the player 
            depth = this.gameObject.transform.position += new Vector3(0, 0, speed * Time.deltaTime);  //depth is speed going forward
           // depth = this.gameObject.transform.position += new Vector3((speed/2)*Time.deltaTime, 0, (speed / 2) * Time.deltaTime);  //depth is speed going forward

            pos = Vector3.Lerp(gameObject.transform.position, player.transform.position + offset, Time.deltaTime);   //capturing the position between the camera 
                                                                                                                     //and the player  then passed to the actual camera position 
                                                                                                                     //gameObject.transform.position = new Vector3(pos.x, offset.y, depth.z);  // Offset - how high above we wanna be 

           // gameObject.transform.position = new Vector3(pos.x, offset.y, depth.z);
        //gameObject.transform.position = new Vector3(pos.x, pos.y, pos.z);  // Offset - how high above we wanna be 
         gameObject.transform.position = new Vector3(0, pos.y, 0); 
        }
        else
        {
            pos = Vector3.Lerp(gameObject.transform.position, player.transform.position + offset, Time.deltaTime);
            gameObject.transform.position = new Vector3(pos.x, offset.y, pos.z);
        }
    }
}
*/

using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour
{

    public GameObject player;       //Public variable to store a reference to the player game object


    private Vector3 offset = new Vector3(0, 4, -2);         //Private variable to store the offset distance between the player and camera

    // Use this for initialization
    void Start()
    {
        //Calculate and store the offset value by getting the distance between the player's position and camera's position.
       // offset = transform.position - player.transform.position;
    }

    // LateUpdate is called after Update each frame
    void LateUpdate()
    {
        // Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
        transform.position = player.transform.position + offset;
    }
}
