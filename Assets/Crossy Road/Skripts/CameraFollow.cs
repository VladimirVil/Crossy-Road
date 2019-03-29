
using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour
{

    public GameObject player;       //Public variable to store a reference to the player game object


    private Vector3 offset = new Vector3(0, 4, -2);         //Private variable to store the offset distance between the player and camera

    // Use this for initialization
    void Start()
    {
      
    }

    // LateUpdate is called after Update each frame after all the objects did their actions
    void LateUpdate()
    {
        // Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
        transform.position = player.transform.position + offset;
    }
}
