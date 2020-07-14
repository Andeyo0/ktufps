using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public float walkSpeed;
    float realSpeed;
    public float rotationspeed;
    public float rotX;
    public float rotY;
    public float rotZ;
    void Update()
    {
        WalkAndRun();
        HorizontalMovement();
        VerticalMovement();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<Rigidbody>().AddForce(Vector3.up * 500);
        }
        rotX -= Input.GetAxis("Mouse Y") * Time.deltaTime * rotationspeed;
        rotY += Input.GetAxis("Mouse X") * Time.deltaTime * rotationspeed;

        if(rotX < -90)
        {
            rotX = -90;
        } else if (rotX > 90)
        {
            rotX = 90;
        }

        transform.rotation = Quaternion.Euler(0, rotY, 0);
        GameObject.FindWithTag("MainCamera").transform.rotation = Quaternion.Euler(rotX, rotY, 0);
    }

    private void WalkAndRun()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            realSpeed = walkSpeed;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            realSpeed = moveSpeed;
        }
    }

    private void VerticalMovement()
    {
        if (Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
        {
            transform.position += transform.TransformDirection(Vector3.left) * Time.deltaTime * realSpeed;
        }
        else if (!Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D))
        {
            transform.position -= transform.TransformDirection(Vector3.left) * Time.deltaTime * realSpeed;
        }
    }

    private void HorizontalMovement()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += transform.TransformDirection(Vector3.forward) * Time.deltaTime * realSpeed;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.position -= transform.TransformDirection(Vector3.forward) * Time.deltaTime * realSpeed;
        }
    }

}
