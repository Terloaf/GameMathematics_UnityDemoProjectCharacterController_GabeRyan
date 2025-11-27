using System.Runtime.CompilerServices;
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
    //movement values
    public float BaseSpeed;
    public float MaxSpeed;
    public float acceleration;
    public float deceleration;
    private float MoveSpeed;
    public float SprintSpeed;
    //Jump Values
    public float JumpSpeed;
    private float ySpeed;
    public float gravity;
    private float JumpMuliplier = -2f;


    //Crouch transform
    public Transform Crouch;
    
    //Vectors
    private Vector3 ControllerInput;
    private Vector3 MovementDirection;
    

    private bool Sprintable;



    

    
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
       //resets players scales to its original value
        transform.localScale = Vector3.one;
        // Checks if you can sprint
        Sprintable = true;

        // checks if player is inputting
        if(ControllerInput != Vector3.zero)
        {
            MovementDirection = ControllerInput;
        }
        ControllerInput = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {
            MoveSpeed = Mathf.MoveTowards(MoveSpeed, MaxSpeed, acceleration * Time.deltaTime);

            ControllerInput += transform.forward;

        }
        if (Input.GetKey(KeyCode.D))
        {
            MoveSpeed = Mathf.MoveTowards(MoveSpeed, MaxSpeed, acceleration * Time.deltaTime);

            ControllerInput += transform.right;
        }
        if (Input.GetKey(KeyCode.A))
        {
            MoveSpeed = Mathf.MoveTowards(MoveSpeed, MaxSpeed, acceleration * Time.deltaTime);
            ControllerInput += -transform.right;
        }
        if (Input.GetKey(KeyCode.S))
        {
            MoveSpeed = Mathf.MoveTowards(MoveSpeed, MaxSpeed, acceleration * Time.deltaTime);
            ControllerInput += -transform.forward;
        }

        if (Input.GetKey(KeyCode.LeftControl))
        {
            
            transform.localScale = Crouch.localScale;
            Sprintable = false;

        }

       
        if (Input.GetKey(KeyCode.LeftShift) && Sprintable == true)
        {
            ControllerInput *= SprintSpeed;
        }

        controller.SimpleMove(ControllerInput * MoveSpeed);

        if (ControllerInput == Vector3.zero)
        {
            MoveSpeed = Mathf.MoveTowards(MoveSpeed, BaseSpeed, deceleration * Time.deltaTime);
            controller.SimpleMove(MovementDirection * MoveSpeed);
        }
        // checks if player is grounded and inputs a jump
        if (Input.GetKey(KeyCode.Space) && controller.isGrounded)
        {
            ySpeed = JumpSpeed * JumpMuliplier * gravity;
            controller.Move(new Vector3(0, ySpeed, 0));
        }


    }
}
