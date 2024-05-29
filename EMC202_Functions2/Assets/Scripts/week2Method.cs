using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum Emovement
{
    Forward,
    Backward,
    Left,
    Right
}

public class week2Method : MonoBehaviour
{
    public float moveSpeed;
    public Emovement movementType;

    public Transform pointA, pointB;
    public float rangeValue;

    private float dist;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //switch (movementType)
        //{
        //    case Emovement.Forward:
        //        MoveForward();
        //        break;
        //    case Emovement.Backward:
        //        MoveBackward();
        //        break;
        //    case Emovement.Left:
        //        MoveLeft(); 
        //        break;
        //    case Emovement.Right:
        //        MoveRight();
        //        break;
        //    default:
        //        break;
        //}

        //Time.deltaTime - time passed from last frame | 0 -> 1 -> reset to 0
        //Time.time - time passed somce the beginning of cycle
        transform.position = Vector3.Lerp(transform.position, pointB.position, moveSpeed * Time.time);
        dist = Vector3.Distance(transform.position, pointB.position);
        //Debug.Log(dist);
        if (dist < rangeValue)
        {
            //Point B is defined on Vector3.Distance so it detects point B
            Debug.Log("Point B detected");
        }
    }

    public void OnDrawGizmos()
    {
        //To debug, for developers
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, rangeValue);
    }

    public void MoveForward()
    {
        //up, down, left, right
        //Time.time - consistent increment of time
        transform.position = Vector3.forward * moveSpeed * Time.time;
    }

    public void MoveBackward()
    {
        //up, down, left, right
        //Time.time - consistent increment of time
        transform.position = Vector3.back * moveSpeed * Time.time;
    }

    public void MoveLeft()
    {
        //up, down, left, right
        //Time.time - consistent increment of time
        transform.position = Vector3.left * moveSpeed * Time.time;
    }
    public void MoveRight()
    {
        //up, down, left, right
        //Time.time - consistent increment of time
        transform.position = Vector3.right * moveSpeed * Time.time;
    }
}
