using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleBullet : MonoBehaviour
{
    private float bulletSpeed=100.0f;
    private Vector3 cameraFront;
    private float correctionOffset = 0.1f;
    private bool hitDetected = false;
    // Start is called before the first frame update
    void Start()
    {
        GameObject camera = GameObject.Find("Main Camera");
        cameraFront = camera.transform.forward+new Vector3(0,correctionOffset,0);
    }

    // Update is called once per frame
    void Update()
    {
        if (!hitDetected)
        {
            moveBullet();
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        hitDetected = true;
        Destroy(gameObject);
    }

    private void moveBullet()
    {
        transform.Translate(cameraFront * Time.deltaTime * bulletSpeed);
        Destroy(gameObject, 2.0f);//destroy the bullet after 2sec
    }
}
