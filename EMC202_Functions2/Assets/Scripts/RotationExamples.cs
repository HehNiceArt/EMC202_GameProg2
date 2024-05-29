using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationExamples : MonoBehaviour
{

    public Quaternion currentRotation;

    float x, y, z;
    public Vector3 currentEulerAngles;
    public float rotSpeed;
    float timeCount = 0.0f;
    public Transform targetA, targetB;
    // Start is called before the first frame update
    void Start()
    {
        //transform.rotation = Quaternion.Euler(90,90,90);

        //resets to default (0,0,0)
       // transform.rotation = Quaternion.identity;
    }

    // Update is called once per frame
    void Update()
    {
        //RotationInputs();
        //QuaternionRotateTowards();
        //QuaternionSlerp();
        LookRotation();
    }

    private void OnGUI()
    {
        GUIStyle style = new GUIStyle();
        style.fontSize = 18;

        //creates a text on top
        //Use the Euler angles to show the euler angles of the transform rotation
        GUI.Label(new Rect(10, 0, 0, 0), "Rotating on X: " + x + " Y: " + y + " Z: " + z, style);
        
        //Outputs the Quaternion.euler angle values
        GUI.Label(new Rect(10, 25, 0, 0), "Current Euler angles " + currentEulerAngles, style);

        //Outputs the transform.eulerAnglers of the gameObject
        GUI.Label(new Rect(10, 50, 0, 0), "Game Object World Euler Angles " + transform.eulerAngles, style);

    }

    void RotationInputs()
    {
        if(Input.GetKeyDown(KeyCode.X))
        {
            x = 1 - x;
        }

        if(Input.GetKeyDown(KeyCode.Y))
        {
            y = 1 - y;
        }
        
        if(Input.GetKeyDown(KeyCode.Z))
        {
            z = 1 - z;
        }

        //Modifies the vector3 based on input multiplied by time and rotSpeed
        currentEulerAngles += new Vector3(x,y,z) * Time.deltaTime * rotSpeed;
        //Moves the value of vector3 into Quaternion.Angle
        currentRotation.eulerAngles = currentEulerAngles;
        //Rotates the gameObject based on the Quaternion.Angle
        transform.rotation = currentRotation;
    }

    void QuaternionRotateTowards()
    {
        var step = rotSpeed * Time.time;
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetA.rotation, step);
    }

    void QuaternionSlerp()
    {
        
        //lerp for vector3
        transform.rotation = Quaternion.Slerp(targetA.rotation, targetB.rotation, timeCount);
        timeCount = timeCount + Time.deltaTime;
    }

    void LookRotation()
    {
        Vector3 relativePos =  targetA.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(relativePos, Vector3.up);
        transform.rotation = rotation;
    }
}
