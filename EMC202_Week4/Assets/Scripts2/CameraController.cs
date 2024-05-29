using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController: MonoBehaviour
{
    public Transform player;
    public Vector3 offset;
    public float smoothSpeed;
    // Start is called before the first frame update
    void Start()
    {
        player = PlayerManager.Instance.player.transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 desiredPosition = player.position + offset;
        Vector3 smoothAnimation = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        transform.position = smoothAnimation;
    }
}
