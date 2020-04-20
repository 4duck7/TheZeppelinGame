using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float MoveSpeed;
    public Rigidbody2D rb;
    public Animator anim;

    Vector2 movement;
    bool facingRight = true;


    void Update() 
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * MoveSpeed * Time.fixedDeltaTime);

        if(facingRight == false && movement.x > 0)
        {
            anim.SetTrigger("flipRotateLeft");            
            Flip();
            
        } else if(facingRight == true && movement.x <0)
        {
            anim.SetTrigger("flipRotateRight");
            Flip();
        }
    }

    void Flip() //I learned that from Blackthornprod Back in The Day <333
    {        

        facingRight = !facingRight;
        Vector3 Scale = transform.localScale;
        Scale.x *= -1;
        transform.localScale = Scale;
    }
}
