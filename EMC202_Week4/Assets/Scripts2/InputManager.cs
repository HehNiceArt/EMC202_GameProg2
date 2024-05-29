using System;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [Header("Movement")]
    private PlayerControl playerControl;
    public Vector2 movementInput;
    public float verticalInput;
    public float horizontalInput;
    public float moveAmount;
    public bool sprintInput;
    public bool walkInput;
    #region
    //Hierarchy:
    //void Awake
    //voide Enable
    #endregion
    private void OnEnable()
    {
        if (playerControl == null)
        {
            playerControl = new PlayerControl();
            //when WASD is pressed, records the movement to variable
            //PlayerMovement is from PlayerControl Input Action
            playerControl.PlayerMovement.Movement.performed += i => movementInput = i.ReadValue<Vector2>();

            playerControl.PlayerAction.Sprint.performed += i => sprintInput = true;
            playerControl.PlayerAction.Sprint.canceled += i => sprintInput = false;

            playerControl.PlayerAction.Walk.performed += i => walkInput = true;
            playerControl.PlayerAction.Walk.canceled += i => walkInput = false;
        }
        playerControl.Enable();
    }

    public void OnDisable()
    {
        playerControl.Disable();
    }

    public void HandleAllInput()
    {
        HandleMovementInput();
        HandleSprinting();
        HandleWalking();
    }

    private void HandleMovementInput()
    {
        verticalInput = movementInput.y;
        horizontalInput = movementInput.x;
        moveAmount = Mathf.Clamp01(Mathf.Abs(horizontalInput) + Mathf.Abs(verticalInput));
        PlayerManager.Instance.playerAnimation.UpdateAnimatorValues(0, moveAmount);
    }
    private void HandleSprinting()
    {
        if (sprintInput && moveAmount > 0.5f)
        {
            PlayerManager.Instance.isSprinting = true;
        }
        else
        {
            PlayerManager.Instance.isSprinting = false;
        }
    }

    private void HandleWalking()
    {
        if (walkInput && moveAmount > 0.1f)
        {
            print("A");
            PlayerManager.Instance.isWalking = true;
        }
        else
        {
            PlayerManager.Instance.isWalking= false;
        }
    }
}