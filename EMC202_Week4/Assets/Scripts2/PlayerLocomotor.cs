using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerLocomotor : MonoBehaviour
{

    Vector3 moveDirection;
    Transform cameraObject;

    private void Awake()
    {

        cameraObject = Camera.main.transform;
    }
    
    public void HandleAllMovement()
    {
        HandleMovement();
        HandleRotation();
    }

    private void HandleMovement()
    {
        moveDirection = cameraObject.forward * PlayerManager.Instance.inputManager.verticalInput;
        moveDirection = moveDirection + cameraObject.right * PlayerManager.Instance.inputManager.horizontalInput;
        moveDirection.Normalize();
        moveDirection.y = 0;

        if (PlayerManager.Instance.isSprinting) { moveDirection *= PlayerManager.Instance.sprintSpeed; }
        else if(PlayerManager.Instance.isWalking) { moveDirection *= PlayerManager.Instance.walkSpeed;  }
        else { moveDirection *= PlayerManager.Instance.movementSpeed; }
        
        Vector3 movementVelocity = moveDirection;
        PlayerManager.Instance.rigidBody.velocity = movementVelocity;
    }
    private void HandleRotation()
    {
        
        Quaternion targetRotation = Quaternion.LookRotation(TargetDirection());
        Quaternion playerRotation = Quaternion.Slerp(transform.rotation, targetRotation, PlayerManager.Instance.rotationSpeed);
        transform.rotation = playerRotation;

        
    }
    private Vector3 TargetDirection()
    {
        Vector3 targetDirection = Vector3.zero;
        targetDirection = cameraObject.forward * PlayerManager.Instance.inputManager.verticalInput;
        targetDirection = targetDirection + cameraObject.right * PlayerManager.Instance.inputManager.horizontalInput;
        targetDirection.Normalize();
        targetDirection.y = 0;

        if (targetDirection == Vector3.zero) { targetDirection = transform.forward; }
        return targetDirection;
    }
}
