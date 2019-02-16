using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorController : MonoBehaviour {


    public PlayerController playerController = null;
    private Animator animator = null;

    void Start()
    {
        animator = this.GetComponent<Animator> ();
    }

    void Update()
    {
        if (playerController.isDead)
        {
            animator.SetBool("dead", true);
        }
        if (playerController.jumpStart)
        {
            animator.SetBool("jumpStart", true);
        }
        else if (playerController.isJumping)
        {
            animator.SetBool("jump", true);
        }
        else
        {
            animator.SetBool("jump", false);

            animator.SetBool("jumpStart", false);

        }

        if (!playerController.isIdle) return;

        //rotation definition using angles in 3 dimensions
        if (Input.GetKey(KeyCode.UpArrow     )) { gameObject.transform.rotation = Quaternion.Euler(270, 0, 0); }
        if (Input.GetKey(KeyCode.DownArrow   )) { gameObject.transform.rotation = Quaternion.Euler(270, 180, 0); }
        if (Input.GetKey(KeyCode.LeftArrow   )) { gameObject.transform.rotation = Quaternion.Euler(270, -90, 0); }
        if (Input.GetKey(KeyCode.RightArrow  )) { gameObject.transform.rotation = Quaternion.Euler(270, 90, 0); }

    }
}
