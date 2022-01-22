using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlayer_Move_Prot : MonoBehaviour
{
    public int playerSpeed = 10;
    public int playerJumpPower = 1;
    private float moveX;
    public bool isGrounded; // is the palyer touching an obstacle or the ground?


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        playerMove();
    }
    
    // check for collision with obstacles/ground and set touchingObstacles accordingly
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Obstacle" || other.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Obstacle" || other.gameObject.tag == "Ground")
        {
            isGrounded = false;
        }
    }
    


    void playerMove()
    {
        // CONTROLS
        moveX = Input.GetAxis("Horizontal");
        if(Input.GetButtonDown("Jump") && this.isGrounded)
        {
            jump();
        }

        // ANIMATIONS
        if(moveX != 0)
        {
            GetComponent<Animator>().SetBool("isWalking", true);
        }
        else
        {
            GetComponent<Animator>().SetBool("isWalking", false);
        }

        // PLAYER DIRECTIONS
        if (moveX < 0.0f)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }else if(moveX > 0.0f)
        {
            GetComponent<SpriteRenderer>().flipX = false;

        }

        // PHYSICS
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2 (moveX * playerSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);
    }

    void jump()
    {
        // add upwards force
        GetComponent<Rigidbody2D>().AddForce(Vector2.up * playerJumpPower);
    }
}
