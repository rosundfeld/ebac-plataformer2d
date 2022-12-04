using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Player : MonoBehaviour
{
    public Rigidbody2D myRigidbody;

    [Header("Setup")]
    public SOPlayerSetup soPlayerSetup;

    [Header("Health Base")]
    public HealthBase healthBase;

    [Header("Utils")]
    public bool falling = false;
    private float _currentSpeed;


    //public Animator animator;

    private Animator _currentPlayerAnimator;
    private void Update()
    {
        checkIfPlayerisFalling();
        HandleJump();
        HandleMoviment();
    }

    private void Awake()
    {
        if (healthBase != null)
        {
            healthBase.OnKill += OnPlayerKill;
        }

        _currentPlayerAnimator = Instantiate(soPlayerSetup.player, transform); //consigo passar por parametro o posição
    }

    private void OnPlayerKill()
    {
        healthBase.OnKill -= OnPlayerKill;
        _currentPlayerAnimator.SetTrigger(soPlayerSetup.triggerDeath);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") && falling)
        {
            handleScaleLanding();
            _currentPlayerAnimator.SetBool(soPlayerSetup.boolLand, false);
        }
        else
        {
            _currentPlayerAnimator.SetBool(soPlayerSetup.boolLand, true);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _currentPlayerAnimator.SetBool(soPlayerSetup.triggerJump, false);
        }
    }


    private void handleScaleLanding()
    {
        myRigidbody.transform.DOScaleY(soPlayerSetup.landingScaleY, soPlayerSetup.animationDuration).SetLoops(2, LoopType.Yoyo); //Quantidade de loops e o tipo de loop
        myRigidbody.transform.DOScaleX(soPlayerSetup.landingScaleX, soPlayerSetup.animationDuration).SetLoops(2, LoopType.Yoyo);
    }


    private void checkIfPlayerisFalling()
    {
        if (myRigidbody.velocity.y < soPlayerSetup.fallingThreshold)
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
        myRigidbody.transform.DOScaleY(soPlayerSetup.jumpScaleY, soPlayerSetup.animationDuration).SetLoops(2, LoopType.Yoyo).SetEase(soPlayerSetup.ease); //Quantidade de loops e o tipo de loop
        myRigidbody.transform.DOScaleX(soPlayerSetup.jumpScaleX, soPlayerSetup.animationDuration).SetLoops(2, LoopType.Yoyo).SetEase(soPlayerSetup.ease); //Quantidade de loops e o tipo de loop
    }

    private void HandleMoviment()
    {

        if (Input.GetKey(KeyCode.LeftShift))
        {
            _currentSpeed = soPlayerSetup.speedRun;
            if ((myRigidbody.velocity.x > 1 || myRigidbody.velocity.x < -1))
            {
                _currentPlayerAnimator.SetBool(soPlayerSetup.boolRun, true);
            }
        }
        else
        {
            _currentSpeed = soPlayerSetup.speed;
            _currentPlayerAnimator.SetBool(soPlayerSetup.boolRun, false);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            //myRigidbody.velocity = new Vector2(Input.GetKey(KeyCode.LeftShift) ? speedRun : speed, myRigidbody.velocity.y); //IF TERNÁRIO, BRABO
            //myRigidbody.MovePosition(myRigidbody.position + speed * Time.deltaTime); //possição do personagem + a posição que ele quer andar + deltaTime para normalizar o tempo

            myRigidbody.velocity = new Vector2(_currentSpeed, myRigidbody.velocity.y);
            if (myRigidbody.transform.localScale.x != 1)
            {
                myRigidbody.transform.DOScaleX(1, .1f);
            }

            _currentPlayerAnimator.SetBool(soPlayerSetup.boolWalk, true);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            //myRigidbody.MovePosition(myRigidbody.position - velocity * Time.deltaTime);
            //myRigidbody.velocity = new Vector2(Input.GetKey(KeyCode.LeftShift) ? -speedRun : -speed, myRigidbody.velocity.y);
            myRigidbody.velocity = new Vector2(-_currentSpeed, myRigidbody.velocity.y);

            if (myRigidbody.transform.localScale.x != -1)
            {
                myRigidbody.transform.DOScaleX(-1, .1f);
            }

            _currentPlayerAnimator.SetBool(soPlayerSetup.boolWalk, true);
        }
        else
        {
            _currentPlayerAnimator.SetBool(soPlayerSetup.boolWalk, false);
        }

        if (myRigidbody.velocity.x > 0)
        {
            myRigidbody.velocity -= soPlayerSetup.friction;
        }
        else
        {
            myRigidbody.velocity += soPlayerSetup.friction;
        }
    }

    private void HandleJump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            myRigidbody.velocity = Vector2.up * soPlayerSetup.forceJump;
            myRigidbody.transform.localScale = Vector2.one;

            DOTween.Kill(myRigidbody.transform);
            _currentPlayerAnimator.SetBool(soPlayerSetup.triggerJump, true);
            handleScaleJump();
        }
    }

    public void DestroyMe()
    {
        Destroy(gameObject);
    }

}