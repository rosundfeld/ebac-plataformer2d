using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public Rigidbody2D myRigidbody;
    public Vector2 friction = new Vector2(.1f, 0);
    public float speed;
    public float forceJump;
    private void Update()
    {
        HandleJump();
        HandleMoviment();
    }

    private void HandleMoviment()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            //myRigidbody.MovePosition(myRigidbody.position + velocity * Time.deltaTime); //possição do personagem + a posição que ele quer andar + deltaTime para normalizar o tempo
            myRigidbody.velocity = new Vector2(speed, myRigidbody.velocity.y);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            //myRigidbody.MovePosition(myRigidbody.position - velocity * Time.deltaTime);
            myRigidbody.velocity = new Vector2(-speed, myRigidbody.velocity.y);
        }

        if (myRigidbody.velocity.x > 0)
        {
            myRigidbody.velocity -= friction;
        }
        else
        {
            myRigidbody.velocity += friction;
        }
    }

    private void HandleJump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            myRigidbody.velocity = Vector2.up * forceJump;
        }
    }
}
