using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    //OnTriggerENter and OnTriggerExit need to be debuged 
public class Mover : MonoBehaviour {

    public float speed = 1.0f;
    public float moveDirection = 0;
    public bool parentOnTrigger = true;
    public bool hitBoxOnTrigger = false;
    public GameObject moverObject = null;

    private Renderer renderer = null;
    private bool isVisible = false;

    void Start()
    {
        //cashing the Renderer into the renderer
        renderer = moverObject.GetComponent<Renderer>();
    }
    void Update()

    {
        //lets move the object
        this.transform.Translate(speed * Time.deltaTime, 0, 0);
        IsVisible();
    }
    void IsVisible ()
    {
        if(renderer.isVisible)
        {
            isVisible = true;
        }
        if (!renderer.isVisible && isVisible)
        {
            Debug.Log("Object not seen anymore by the camera, remove");
            //will destroy the object once it is not on the screen
            Destroy(this.gameObject);
        }
    }

     void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("mover hit the player");
            if(parentOnTrigger)
            {
                Debug.Log("Enter - parent to me");
                other.transform.parent = this.transform;
            }
            if(hitBoxOnTrigger)
            {
                Debug.Log("Got hit. Game over");
                other.GetComponent<PlayerController>().GotHit();

            }
        }
    }

     void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            if(parentOnTrigger)
            {
                Debug.Log("mover exit  player");

                other.transform.parent = null;
            }
        }
    }
}
