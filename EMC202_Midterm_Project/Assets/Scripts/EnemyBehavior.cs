using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    [SerializeField]
    private GameObject remove;

    private Transform target;
    public int moveSpeed;
    public MeshRenderer rend;
    public Material colorMat;
    public static EnemyBehavior Instance;

    public Material mat
    {
        get
        {
            return rend.material;
        }
    }

    // Start is called before the first frame update
    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        transform.LookAt(target);

        rend.material.color = ColorBehavior.Instance.RandomColor();
        //print(rend.material.color);
    }

    private void FixedUpdate()
    {
        GetComponent<Rigidbody>().velocity = moveSpeed * Time.deltaTime * transform.forward;
    }

    private void OnCollisionEnter(Collision collision)
    {
        //var myColor = ColorBehavior.Instance.colors;
        //var otherColor = rend.material.color;
        //print(otherColor);
        //print(myColor);
        if (collision.gameObject.tag == "Player")
        {
            Destroy(collision.gameObject);
        }
    }
}