using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 startPos;
    private Quaternion startRo;
    public float BaseSpeed;
    public float MaxSpeed;
    public float movespeed;
    public float acceleration;
    public float deceleration;
    private float speed;
   
    private bool isGrounded;


    private Vector3 targetFace;

    

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        controller = GetComponent<CharacterController>();
        
 
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }
    private void FixedUpdate()
    {
        PlayerInput();
    }

    void PlayerInput()
    {
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");


        if (Input.anyKey == true)
        {
            speed = Mathf.MoveTowards(speed, MaxSpeed, acceleration * Time.deltaTime);

            if (Input.GetKey(KeyCode.W))
            {

                controller.SimpleMove(transform.forward * speed);


            }
            if (Input.GetKey(KeyCode.D))
            {

                controller.SimpleMove(transform.right * speed);

            }
            if (Input.GetKey(KeyCode.A))
            {

                controller.SimpleMove(-transform.right * speed);
            }
            if (Input.GetKey(KeyCode.S))
            {

                controller.SimpleMove(-transform.forward * speed);
            }

            if (Input.GetKey(KeyCode.LeftArrow))
            {

                transform.rotation *= Quaternion.Euler(0, -2, 0);
            }

            if (Input.GetKey(KeyCode.RightArrow))
            {

                transform.rotation *= Quaternion.Euler(0, 2, 0);
            }

           
        }

      


        
    }
}
