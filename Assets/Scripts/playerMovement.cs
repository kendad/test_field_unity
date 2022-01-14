using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    //PUBLIC VARIABLES
    public GameObject camera;
    //PRIVATE VARIABLES
    private float velocity = 10.0f;
    private float rotateSpeed = 5.0f;
    private bool isGrounded=true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //character movement
        //Forward
        if (Input.GetKey(KeyCode.W))
        {
            turnPlayer();
            transform.Translate(Vector3.forward*Time.deltaTime*velocity,Space.Self);
        }
        //Backward
        if (Input.GetKey(KeyCode.S))
        {
            turnPlayer();
            transform.Translate(-Vector3.forward * Time.deltaTime * velocity, Space.Self);
        }
        //Right
        if (Input.GetKey(KeyCode.D))
        {
            turnPlayer();
            transform.Translate(Vector3.right * Time.deltaTime * velocity,Space.Self);
        }
        //Left
        if (Input.GetKey(KeyCode.A))
        {
            turnPlayer();
            transform.Translate(-Vector3.right * Time.deltaTime * velocity,Space.Self);
        }
        //jump
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Rigidbody playerPhyics = gameObject.GetComponent<Rigidbody>();
            playerPhyics.AddForce(transform.up*40.0f,ForceMode.Impulse);
        }
    }

    //rotates the character towards the camera direction
   void turnPlayer()
    {
        float smoothness = 10.0f;
        Quaternion rotateAngle = Quaternion.Euler(0, camera.transform.eulerAngles.y, 0);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotateAngle, Time.deltaTime * smoothness);
    }
}
