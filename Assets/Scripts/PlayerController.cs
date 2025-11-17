using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{

    private Vector3 startPos;
    public float movespeed;
    public Rigidbody rb;
    private bool movementIsEnabled = true;
    private bool isGrounded;

    private Vector3 forward;
    private Vector3 up;

    public GameObject player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
 
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
        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(Vector3.forward * movespeed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(Vector3.right * movespeed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(Vector3.left * movespeed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(Vector3.back * movespeed);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.rotation = Quaternion.Euler(1, 0, 0);
        }

    }
}
