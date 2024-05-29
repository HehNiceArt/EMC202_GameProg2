using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testMethods : MonoBehaviour
{

    public Vector3 screenPoint;
    private Vector3 offset;
    public float delayTime;
    public float interval;
    public List<Color> color;
    public MeshRenderer meshRenderer;
    // Start is called before the first frame update
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();

        
    }

    public void changeColor()
    {
        for (int i = 0; i < color.Count; i++)
        {
            //access material inisde the meshrenderer
            meshRenderer.material.color = color[Random.Range(0, color.Count)];
        }
    }

    private void OnEnable()
    {
        
    }

    private void OnDisable()
    {

    }

    //Left click
    private void OnMouseDown()
    {
       InvokeRepeating("changeColor", delayTime, interval);

        //Drag and drop the object
       screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position); 
       offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
       
    }

    private void OnMouseUpAsButton()
    {
        CancelInvoke();
    }
    //when mouse enters the gameobject
    private void OnMouseEnter()
    {
 
    }

    //when mouse leaves the gameobject
    private void OnMouseExit()
    {
        
    }

    private void OnMouseOver()
    {
        //x.xf -> f is float
        //Invoke("changeColor", delayTime);
        
    }

    private void OnMouseDrag()
    {
        Vector3 cursorPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(cursorPoint) + offset;
        transform.position = cursorPosition;
    }

    

    // Update is called once per frame
    void Update()
    {
        
    }

    //50 calls per second
    //Used for physics
    void FixedUpdate()
    {

    }

    //last to be called
    void LateUpdate()
    {
        
    }

}
