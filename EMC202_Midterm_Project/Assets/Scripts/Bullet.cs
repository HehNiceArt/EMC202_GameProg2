using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody rb;
    private MeshRenderer rend;
    private MeshRenderer render;

    //ColorBehavior colorBehavior;
    // Start is called before the first frame update
    private void Start()
    {
        //colorBehavior = GetComponent<ColorBehavior>();
        rb = GetComponent<Rigidbody>();
        rend = GetComponent<MeshRenderer>();
        rend = ColorBehavior.Instance.GetComponent<MeshRenderer>(); ;
        var myColor = ColorBehavior.Instance.ChangeBulletColor();

        rend.sharedMaterial.color = myColor;
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    //var bulletColor = colorBehavior.bullet.sharedMaterial.color;
    //    //var enemyColor = EnemyBehavior.Instance.rend.material.color;
    //    //if (collision.gameObject.tag == "Enemy")
    //    //{
    //    //    print("a");
    //    //        Destroy(collision.gameObject);
    //    //        Destroy(this.gameObject);

    //    //}
    //}
    private void OnCollisionEnter(Collision collision)
    {
        //var bulletColor = GetComponent<Renderer>().material.color;
        //ColorBehavior.Instance.bullet.sharedMaterial.color;
        //var enemyColor = EnemyBehavior.Instance.rend.material.color;
        if (collision.gameObject.tag == "Enemy")
        {
            //if (bulletColor.Equals(enemyColor))
            //{
            //    print("a");
            //}

            Destroy(this.gameObject);
            Destroy(collision.gameObject);
        }
    }
}