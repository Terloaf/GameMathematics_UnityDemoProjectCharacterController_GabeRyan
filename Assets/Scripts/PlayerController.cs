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
    public float minMoveSpeed;
    public float movespeed;
    private Vector3 forwardAcceleration;
   
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
        forwardAcceleration = Vector3.MoveTowards(Vector3.zero, transform.forward, movespeed);
    }
    private void FixedUpdate()
    {
        PlayerInput();
    }

    void PlayerInput()
    {
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");
        


 
        if (Input.GetKey(KeyCode.W))
        {
            controller.SimpleMove(transform.forward * movespeed);

            
        }

        if (Input.GetKey(KeyCode.D))
        {
            controller.SimpleMove(transform.right * movespeed);

        }
        if (Input.GetKey(KeyCode.A))
        {
            controller.SimpleMove(-transform.right * movespeed );
        }
        if (Input.GetKey(KeyCode.S))
        {
            controller.SimpleMove(-transform.forward * movespeed);
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
