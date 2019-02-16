using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    //Camera moves but  doesn't follow properly the player. Need to debug    
    public float speed = 0.2f;
    public bool autoMove = true;
    public GameObject player = null;
    //camera location
    //public Vector3 offset = new Vector3(3, 6, -3);
    public Vector3 offset = new Vector3(0, 6, 0);
    Vector3 depth = Vector3.zero;   //how high the camera is 
    Vector3 pos = Vector3.zero;

    void Update()
   // void LateUpdate()
        {
        if (!Manager.instance.CanPlay()) return;

        if (autoMove)
        {
            //camera should go forward with the player 
            depth = this.gameObject.transform.position += new Vector3(0, 0, speed * Time.deltaTime);  //depth is speed going forward
            //depth = this.gameObject.transform.position += new Vector3((speed/2)*Time.deltaTime, 0, (speed / 2) * Time.deltaTime);  //depth is speed going forward

            pos = Vector3.Lerp(gameObject.transform.position, player.transform.position + offset, Time.deltaTime);   //capturing the position between the camera 
                                                                                                                     //and the player  then passed to the actual camera position 
                                                                                                                     //gameObject.transform.position = new Vector3(pos.x, offset.y, depth.z);  // Offset - how high above we wanna be 
         gameObject.transform.position = new Vector3(pos.x, pos.y, pos.z);  // Offset - how high above we wanna be 
         //gameObject.transform.position = new Vector3(0, pos.y, 0); 
        }
        else
        {
            pos = Vector3.Lerp(gameObject.transform.position, player.transform.position + offset, Time.deltaTime);
            gameObject.transform.position = new Vector3(pos.x, offset.y, pos.z);
        }
    }
}
