using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Player : MonoBehaviour
{

    [Header("Speed Setup")]
    public Rigidbody2D myRigidbody;
    public Vector2 friction = new Vector2(.1f, 0);
    public float speed;
    public float speedRun;
    public float forceJump;

    [Header("Animation Setup")]
    public float jumpScaleY = 1.5f;
    public float jumpScaleX = 0.7f;

    public float landingScaleY = 0.7f;
    public float landingScaleX = 1.5f;


    public float fallingThreshold = -6f;
    public bool falling = false;
    public float animationDuration = .3f;
    public Ease ease = Ease.OutBack;

    private float _currentSpeed;
    //private bool _isRunning = false;
    private void Update()
    {
        checkIfPlayerisFalling();
        HandleJump();
        HandleMoviment();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //COLOQUEI UMA TAG DE GROUND NOS BLOCOS DE CHÃO PARA VERIFICAR A QUEDA
        if (collision.gameObject.CompareTag("Ground") && falling)
        {
            handleScaleLanding();
        }
    }

    private void handleScaleLanding()
    {
        //A MESMA DO JUMPING SÓ QUE INVERTIDA
        myRigidbody.transform.DOScaleY(landingScaleY, animationDuration).SetLoops(2, LoopType.Yoyo); //Quantidade de loops e o tipo de loop
        myRigidbody.transform.DOScaleX(landingScaleX, animationDuration).SetLoops(2, LoopType.Yoyo); //Quantidade de loops e o tipo de loop
    }


    private void checkIfPlayerisFalling()
    {
        //SE A VELOCIADE DE QUEDA DO PLAYER ESTIVER ACIMA DO THRESHOLD, É CONSIDERADO QUE ELE ESTÁ CAINDO, A FUNÇÃO É CHAMADA NO UPDATE PARA SEMPRE VERIFICAR SE ELE ESTÁ CAINDO
        if (myRigidbody.velocity.y < fallingThreshold)
        {
            falling = true;
        }
        else
        {
            falling = false;
        }
    }




    private void handleScaleJump()
    {
        myRigidbody.transform.DOScaleY(jumpScaleY, animationDuration).SetLoops(2, LoopType.Yoyo).SetEase(ease); //Quantidade de loops e o tipo de loop
        myRigidbody.transform.DOScaleX(jumpScaleX, animationDuration).SetLoops(2, LoopType.Yoyo).SetEase(ease); //Quantidade de loops e o tipo de loop
    }

    private void HandleMoviment()
    {
        //ESSE É BACANA
        // if (Input.GetKey(KeyCode.LeftShift))
        // {
        //     _currentSpeed = speedRun;
        // }
        // else
        // {
        //     _currentSpeed = speed;
        // }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            //myRigidbody.MovePosition(myRigidbody.position + velocity * Time.deltaTime); //possição do personagem + a posição que ele quer andar + deltaTime para normalizar o tempo
            myRigidbody.velocity = new Vector2(Input.GetKey(KeyCode.LeftShift) ? speedRun : speed, myRigidbody.velocity.y); //IF TERNÁRIO, BRABO
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            //myRigidbody.MovePosition(myRigidbody.position - velocity * Time.deltaTime);
            myRigidbody.velocity = new Vector2(Input.GetKey(KeyCode.LeftShift) ? -speedRun : -speed, myRigidbody.velocity.y);
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
            myRigidbody.transform.localScale = Vector2.one;

            DOTween.Kill(myRigidbody.transform);
            handleScaleJump();

        }
    }

}