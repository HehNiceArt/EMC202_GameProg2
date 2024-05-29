using System.Collections.Generic;
using UnityEngine;

public class ColorBehavior : MonoBehaviour
{
    public List<Color> colors;

    //public Color[] color;
    [Header("Material")]
    public MeshRenderer parent;

    public MeshRenderer bullet;
    public GameObject bulletGameObject;

    // public Renderer bulletRend;
    //private GameObject[] coloredChilds;
    public static ColorBehavior Instance;

    public int index;
    private int randIndex;

    // Start is called before the first frame update
    private void Start()
    {
        Instance = this;
        parent = GetComponent<MeshRenderer>();
        parent.sharedMaterial.color = colors[index];
        bulletGameObject.tag = "Red";
        //bullet.material.color = colors[index];
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ChangeColor();
        }
    }

    public Color RandomColor()
    {
        randIndex = Random.Range(0, colors.Count);
        return colors[randIndex];
    }

    //private void OnMouseDown()
    //{
    //}
    public void ChangeColor()
    {
        index += 1;

        if (index == colors.Count) { index = 0; }
        parent.sharedMaterial.color = colors[index];
        //child.sharedMaterial.color = colors[index];

        ChangeBulletColor();

        // bullet.sharedMaterial.color = colors[index];

        //bulletRend.GetComponent<MeshRenderer>().material.color = colors[index];

        //if (index == 0) { bulletGameObject.tag = "Red"; }
        //if (index == 1) { bulletGameObject.tag = "Green"; }
        //if (index == 2) { bulletGameObject.tag = "Blue"; }
    }

    public Color ChangeBulletColor()
    {
        if (index == colors.Count) { index = 0; }
        bullet.sharedMaterial.color = colors[index];
        //gameObject.GetComponent<MeshRenderer>().material.color = colors[index];

        //bullet.GetComponent<MeshRenderer>().material.color = colors[index];
        if (index == 0) { bulletGameObject.tag = "Red"; }
        if (index == 1) { bulletGameObject.tag = "Green"; }
        if (index == 2) { bulletGameObject.tag = "Blue"; }

        return bullet.sharedMaterial.color;
    }
}