using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseAimCamera : MonoBehaviour
{
    //PUBLIC VARIABLES
    public GameObject target;
    //PRIVATE VARIABLES
    private float rotateSpeed = 5.0f;
    private Vector3 offset;
    private float maxX = -0.3f;
    private float minX = 0.3f;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        offset = target.transform.position - transform.position;
        offset += new Vector3(0,-0.5f,0);//offset the camera along the Y a bit
    }

    // Update is called once per frame
    void LateUpdate()
    {
        float horizontal = Input.GetAxis("Mouse X") * rotateSpeed;
        float vertical = Input.GetAxis("Mouse Y") * rotateSpeed;
        //rotate camera up and down
        transform.Rotate(-vertical, 0, 0, Space.Self);

        //move the camera behind the player
        transform.position = target.transform.position - (offset);
        transform.RotateAround(target.transform.position, Vector3.up, horizontal);//rotate the camera with the character at center
        offset = target.transform.position - transform.position;
    }
}
