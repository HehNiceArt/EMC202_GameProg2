// Ignore Spelling: Behaviour

using UnityEngine;

public class ShootingBehavior : MonoBehaviour
{
    [Header("---Bullet---")]
    [SerializeField]
    private GameObject bulletPrefab;

    public Transform bulletSpawnPoint;
    private GameObject bullet;
    public float bulletSpeed;
    public float fireRate;

    //private bool canShoot = false;
    public float timeToLive = 5f;

    [Header("---Enemy---")]
    private Transform enemy;

    public PlayerBehaviour PlayerBehaviour;
    private float rangeValue;

    // Start is called before the first frame update
    private void Start()
    {
        rangeValue = PlayerBehaviour.rangeValue;
        enemy = GameObject.FindGameObjectWithTag("Enemy").transform;
        InvokeRepeating("Fire", 1f, fireRate);
    }

    // Update is called once per frame
    private void Update()
    {
        enemy = GameObject.FindGameObjectWithTag("Enemy").transform;
        //if (Input.GetMouseButtonDown(0) && !canShoot) {
        //    Debug.Log("a");

        // StartCoroutine(FireShot()); }

        Destroy(bullet, timeToLive);
        float dist = Vector3.Distance(transform.position, enemy.transform.position);
        if (dist <= rangeValue)
        {
            LookRotation();
        }
    }

    private void LookRotation()
    {
        Vector3 relativePos = enemy.position - transform.position;
        // the second argument, upwards, defaults to Vector3.up
        Quaternion rotation = Quaternion.LookRotation(relativePos, Vector3.up);
        transform.rotation = rotation;
    }

    //private IEnumerator FireShot()
    //{
    //    canShoot = true;
    //    Fire();
    //    yield return new WaitForSeconds(fireRate);
    //    canShoot = false;
    //}

    private void Fire()
    {
        //bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, Player.transform.rotation);
        bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.identity);
        bullet.GetComponent<Rigidbody>().AddForce(transform.forward * bulletSpeed * 10f);
        //Rigidbody rb = bullet.GetComponent<Rigidbody>();
        //rb.AddForce(transform.forward * bulletSpeed);
        //rb.velocity = transform.TransformDirection(new Vector3(bulletSpeed, 0, bulletSpeed));
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.tag == "Enemy")
    //    {
    //        Debug.Log("a");
    //        Destroy(this.gameObject);
    //    }
    //}
}