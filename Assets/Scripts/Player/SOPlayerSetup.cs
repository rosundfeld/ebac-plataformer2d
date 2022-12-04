using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[CreateAssetMenu]

public class SOPlayerSetup : ScriptableObject
{
    public Animator player;
    public SOString soStringName;
   
    [Header("Speed Setup")]
    public Rigidbody2D myRigidbody;
    public Vector2 friction = new Vector2(.1f, 0);
    public float speed;
    public float speedRun;
    public float forceJump;


    [Header("Animation Setup")]
    public float jumpScaleY = 1.2f;
    public float jumpScaleX = 0.9f;

    public float landingScaleY = 0.9f;
    public float landingScaleX = 1.2f;

    public float fallingThreshold = -6f;
    public float animationDuration = .3f;
    public Ease ease = Ease.OutBack;



     [Header("Animation Player")]
    public string boolRun = "Run";
    public string boolWalk = "Walk";
    public string boolLand = "Land";
    public string triggerJump = "Jump";
    public string triggerDeath = "Death";
}