using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharcaterMovement : MonoBehaviour
{
    Rigidbody robot;
    // Start is called before the first frame update
    void Start()
    {
        robot = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            robot.velocity = new Vector3(0, 5f, 0);
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            transform.position += Vector3.forward;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            transform.position += Vector3.right;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.position += Vector3.left;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            transform.position += Vector3.back;
        }
    }
}
