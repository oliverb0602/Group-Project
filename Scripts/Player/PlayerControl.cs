using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerControl : MonoBehaviour
{
    SenseSlider sense;
    Rigidbody rbPlayer;

    public float jumpHeight = 10f;
    public bool isGrounded;
    public float speed;
    public Transform cam;
    private float xRotation = 0f;
    public float moveSpeed = 30f;
    public CapsuleCollider Player;
    public Camera MainCam;


    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        rbPlayer = GetComponent<Rigidbody>();

        HowToPlay();
        

    }

    // Update is called once per frame
    // FixedUpdate function is similarly to Update function but differs in that it is called on a regular timeline(i.e.the same time between calls)
    void Update()
    {
        Move();
        Jump();
        CameraRotate();
        crouch();
        
    }

    void HowToPlay()
    {
        Debug.Log("Welcome to the game");
        Debug.Log("Use 'WASD' or arrow keys to move your player");
    }

    void Move()
    {
        float xValue = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        float zValue = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;

        transform.Translate(xValue, 0, zValue);
    }

    void Jump()
    {
        if(isGrounded){

       
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rbPlayer.AddForce(Vector3.up * jumpHeight, (ForceMode)ForceMode2D.Impulse);
            } 
        }
    }

    void CameraRotate()
    {
        float mouseX = Input.GetAxis("Mouse X") * speed * 10 * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * speed * 10 * Time.deltaTime;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        
        cam.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        this.gameObject.transform.Rotate(Vector3.up * mouseX);
    }

    void crouch()
    {
        
        if (Input.GetKey(KeyCode.C))
        {
            Player.height = 0.8f;

            
            Debug.Log("Crouched");
        }
        else
        {
            Player.height = 2f;

            
        }

    }

    public void AdjustSpeed(float newSpeed)
    {
        speed = newSpeed;

    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }
    void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "Ground")
        {
            isGrounded = false;
        }
    }
}

