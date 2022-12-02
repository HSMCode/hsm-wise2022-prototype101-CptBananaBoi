using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float horizontalInput;
    public float forwardInput;
    public float speed;
    public float turnspeed;
    public Rigidbody rb;
    public float jumpheight;
    public LayerMask GroundMask;
    public bool isGrounded;
    public Transform GroundCheck;
    public float GroundDistance;

    public Animator _playerAnim;


    // Start is called before the first frame update
    void Start()
    {
        speed = 10;
        turnspeed = 3;
        jumpheight = 6;
        GroundDistance = 0.2f;

        _playerAnim = GetComponent<Animator>();


        //for jump
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");

        //movement
        transform.Translate(Vector3.forward * forwardInput * Time.deltaTime * speed);
        transform.Rotate(Vector3.up * horizontalInput * Time.deltaTime * turnspeed);

        //Jump
        if(Input.GetButton("Jump") && isGrounded)
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpheight, rb.velocity.z);
        }
            else
        {

        }

        //Groundcheck
        isGrounded = Physics.CheckSphere(GroundCheck.position, GroundDistance, GroundMask);

        //Animation Run
        if(forwardInput > 0 || forwardInput < 0)
        {
            _playerAnim.SetBool("IsRunning", true);
        }
        else
        {
            _playerAnim.SetBool("IsRunning", false);
        }
    }
}
