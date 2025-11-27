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
    public float BaseSpeed;
    public float MaxSpeed;
    public float acceleration;
    public float deceleration;
    private float MoveSpeed;
    public float SprintSpeed;
    public Vector3 velocity;

    public float JumpSpeed;
    private float ySpeed;
    public float gravity;
    private float JumpMuliplier = -2f;



    public Transform Crouch;
    

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
       
        transform.localScale = Vector3.one;
        Sprintable = true;

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

        if (Input.GetKey(KeyCode.Space) && controller.isGrounded)
        {
            ySpeed = JumpSpeed * JumpMuliplier * gravity;
            controller.Move(new Vector3(0, ySpeed, 0));
        }


    }
}
