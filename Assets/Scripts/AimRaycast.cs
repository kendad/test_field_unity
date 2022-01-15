using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AimRaycast : MonoBehaviour
{
    //PUBLIC VARIBALES
    public GameObject mouseCursor;
    public GameObject simpleBullet;
    public GameObject player;
    //PRIVATE VARIABLES
    private Animator playerAnimator;
    private Image mouseCursorImage;
    private GameObject front;
    private GameObject hitObject;
    private float rayCastDistance = 100.0f;
    // Start is called before the first frame update
    void Start()
    {
        //Get the mouse image
        mouseCursor = mouseCursor.transform.Find("white").gameObject;
        mouseCursorImage = mouseCursor.GetComponent<Image>();
        //get the front of the player
        front = player.transform.Find("front").gameObject;
        //get the Animator
        playerAnimator = player.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //Shooting is False intialy
        playerAnimator.SetBool("isShooting",false);
        //Ray casting from center of camera
        var ray = new Ray(transform.position, transform.forward);
        mouseCursorImage.color = new Color(1, 1, 1, 1);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit, rayCastDistance))
        {
            mouseCursorImage.color = new Color(255,0,0,100);
        }
        //Shooting done here
        if (Input.GetKey(KeyCode.Mouse0))
        {
            turnPlayer();
            StartCoroutine(simpleBulletShoot());
        }
    }

    void turnPlayer()
    {
        float smoothness = 20.0f;
        Quaternion rotateAngle = Quaternion.Euler(0, this.transform.eulerAngles.y, 0);
        player.transform.rotation = Quaternion.Slerp(player.transform.rotation, rotateAngle, Time.deltaTime * smoothness);
    }

    IEnumerator simpleBulletShoot()
    {
        playerAnimator.SetBool("isShooting",true);
        float delay = 0.05f;
        float rotationAngle = Random.Range(0.5f, 0.9f);
        Instantiate(simpleBullet, (front.transform.forward * 0.5f) + front.transform.position, Quaternion.identity);
        transform.Rotate(new Vector3(0,rotationAngle,0),Space.Self);
        yield return new WaitForSeconds(delay);
        transform.Rotate(new Vector3(0,-rotationAngle, 0), Space.Self);
    }
}
