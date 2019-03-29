using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float moveDistance = 1;
    public float moveTime = 0.4f;
    public float colliderDistCheck = 1;  // fot the colliding
    public bool isIdle = true;
    public bool isDead = false;
    public bool isMoving = false;
    public bool isJumping = false;
    public bool jumpStart = false;
    public ParticleSystem particle = null;
    public GameObject chick = null;
    private Renderer renderer = null;
    private bool isVisible = false;


    void Start()
    {
        //cach the renderer
        renderer = chick.GetComponent<Renderer>();
    }
    void Update()
    {
        if (!Manager.instance.CanPlay()) return;
        //if the player getting hit, then we wanna return immediately
        if(isDead) return ;

        //the following gonna be constantly checked as long as the player not dead 
        CanIdle();
        CanMove();
        IsVisible();
    }

    void CanIdle()
    {
        if (isIdle)
        {
            if  (Input.GetKeyDown(KeyCode.UpArrow) || 
                Input.GetKeyDown(KeyCode.DownArrow) ||
                Input.GetKeyDown(KeyCode.LeftArrow) ||
                Input.GetKeyDown(KeyCode.RightArrow))
            {
                CheckIfCanMove();
            }
                
        }
    }
    void CheckIfCanMove()
    {
        //we need to find if there is any collider object in front of player

        RaycastHit hit;
        Physics.Raycast(this.transform.position, -chick.transform.up, out hit, colliderDistCheck);

        Debug.DrawRay(this.transform.position, -chick.transform.up * colliderDistCheck, Color.red, 2);

        if (hit.collider == null)
        {
            SetMove();
        }
        else
        {
            //check if we hit object with tag collider
            if (hit.collider.tag == "collider")
            {
                Debug.Log("hit object with collider tag");
            }
            else 
            {
                SetMove();
            }
        }

        SetMove();

    }
    void SetMove()
    {
        Debug.Log("Hit nothing, keep moving");
        isIdle = false;
        isMoving = true;
        jumpStart = true;
    }
    void CanMove()
    {
        if (isMoving)
        { 
            //moving 1 "move unit" forward
            if (Input.GetKeyUp(KeyCode.UpArrow)) { Moving(new Vector3(transform.position.x, transform.position.y, transform.position.z + moveDistance)); SetMoveForwardState(); }
            else if (Input.GetKeyUp(KeyCode.DownArrow)) { Moving(new Vector3(transform.position.x, transform.position.y, transform.position.z - moveDistance)); }
            else if (Input.GetKeyUp(KeyCode.LeftArrow)) { Moving(new Vector3(transform.position.x - moveDistance, transform.position.y, transform.position.z)); }
            else if (Input.GetKeyUp(KeyCode.RightArrow)) { Moving(new Vector3(transform.position.x + moveDistance, transform.position.y, transform.position.z)); }

        }
    }
    void Moving(Vector3 pos)
    {
        isIdle = false;
        isMoving = false;
        //next one to happen, thus true
        isJumping = true;
        jumpStart = false;
        //moving using LeanTween, will call MoveComplete after the movement
        LeanTween.move(this.gameObject, pos, moveTime).setOnComplete(MoveComplete);
    }
    void MoveComplete()
    {
        isJumping = false;
        isIdle = true;
    }

    void SetMoveForwardState()
    {
        Manager.instance.UpdateDistanceCount();
    }
    void IsVisible()
    {
        //is the actual object seeable 
        if (renderer.isVisible)
        {
            //if seen once by the camera
            isVisible = true;
        }

        //player moved off a camera view
        if (!renderer.isVisible&&isVisible)
        {
            Debug.Log("Player off screen. APply gotHit()");
            GotHit();
        }
    }

    public void GotHit()
    {
        isDead = true;
        //enabling emision state for the particle
        ParticleSystem.EmissionModule em = particle.emission;
        em.enabled = true;

        Manager.instance.GameOver();
    }




}
