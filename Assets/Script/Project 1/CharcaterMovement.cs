using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float horizontalInput;
    private float forwardInput;
    [SerializeField] float turnSpeed;
    [SerializeField] float speed;

    private Animator _playerAnim;

    private Rigidbody _playerRb;
    public float force;
    public float gravityModifier = 1f;

    public bool isOnGround;
    public bool isJumping;
    public bool isFalling;
    public bool isLanding;

    public bool jumpCancelled;
    public float jumpTimer;
    public float jumpButtonPressedTime = 1f;

    void Start()
    {
        _playerAnim = GetComponent<Animator>();
        _playerRb = GetComponent<Rigidbody>();

    }

    void Update()
    {

        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");

        transform.Rotate(Vector3.up * horizontalInput * Time.deltaTime * turnSpeed);
        transform.Translate(Vector3.forward * forwardInput * Time.deltaTime * speed);

        _playerAnim.SetFloat("Run", forwardInput);

        if (forwardInput != 0 || horizontalInput != 0)
        {
            _playerAnim.SetBool("Walk", true);
        }
        else
        {
            _playerAnim.SetBool("Walk", false);
        }

        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !isFalling)
        {
            isOnGround = false;
            isJumping = true;

            if (isJumping)
            {
                _playerAnim.SetTrigger("Jump");

            }
        }

        if (isJumping)
        {
            jumpTimer += Time.deltaTime;
            if (Input.GetKeyUp(KeyCode.Space))
            {
                isJumping = false;
                isFalling = true;

                if (isFalling)
                {
                    _playerAnim.SetBool("Falling Idle (1)", true);
                }
            }
            if (jumpTimer > jumpButtonPressedTime)
            {
                isJumping = false;
                jumpCancelled = true;
            }
        }

        if (_playerRb.velocity.y < 0 && isFalling)
        {
            isFalling = false;
            isLanding = true;
            _playerAnim.SetBool("Fall", false);
        }
    }

    void FixedUpdate()
    {
        if (isJumping)
        {
            gravityModifier = 1f;
            _playerRb.AddForce(Vector3.up * force, ForceMode.Force);
        }

        if (isFalling || isOnGround || isLanding || jumpCancelled)
        {
            gravityModifier = 30f;
        }

        _playerRb.AddForce(Physics.gravity * (gravityModifier - 1) * _playerRb.mass);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("floor"))
        {
            isOnGround = true;
            jumpTimer = 0;
            jumpCancelled = false;

            if (isLanding)
            {
                _playerAnim.SetBool("Falling to Landing", false);
                isLanding = false;
            }
        }
    }

}