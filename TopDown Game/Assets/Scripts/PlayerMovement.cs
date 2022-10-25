using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public GameObject bullet;

    //moving
    public Animator anim;
    public float moveSpeed;
    public float runSpeed;
    public Rigidbody2D rb;

    Vector2 movement;

     void Update()
    {
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");
        //shooting
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(bullet, transform.position, Quaternion.identity);
        }
    }

    void FixedUpdate()
    {
        //animaiton conditions
        anim.SetFloat("Horizontal", movement.x);
        anim.SetFloat("Vertical", movement.y);
        anim.SetFloat("Magnitude", movement.magnitude);

        //moving
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        //running
        if (movement.magnitude > 0 && Input.GetKey(KeyCode.LeftShift))
        {
            anim.SetBool("isRunning", true);
            rb.MovePosition(rb.position + movement * (moveSpeed + runSpeed) * Time.fixedDeltaTime);
        }
        else
        {
            anim.SetBool("isRunning", false);
        }

    }


}
