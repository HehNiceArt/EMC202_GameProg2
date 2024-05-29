using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    
    public static PlayerManager Instance { get; private set; }
    [Header("Game Object")]
    //Player GameObject
    public GameObject player;
    public Rigidbody rigidBody;
    //PlayerScrpts
    [Header("Player Script")]
    public InputManager inputManager;
    PlayerLocomotor playerLocomotor;
    //Player Stats
    [Header("Player Stats")]
    [Range(0f, 5f)]
    public float movementSpeed;
    [Range(0f, 1f)]
    public float rotationSpeed;
    public float sprintSpeed;
    public float walkSpeed;

    [Header("Animation")]
    public PlayerAnimation playerAnimation;
    public Animator playerAnim;

    [Header("Action States")]
    public bool isSprinting;
    public bool isWalking;
    public bool isJumping;
    public void Awake()
    {
        //if two or more instance, delete self, else use self
        if(Instance != null && Instance != this) { Destroy(this); }
        else { Instance = this; }
        inputManager = player.GetComponent<InputManager>();
        playerLocomotor = player.GetComponent<PlayerLocomotor>();
        rigidBody = player.GetComponent<Rigidbody>();
        playerAnim = player.GetComponentInChildren<Animator>();
        playerAnimation = player.GetComponentInChildren<PlayerAnimation>();
    }

    // Update is called once per frame
    private void Update()
    {
        inputManager.HandleAllInput();
    }
    private void FixedUpdate()
    {
        playerLocomotor.HandleAllMovement();
    }
}
