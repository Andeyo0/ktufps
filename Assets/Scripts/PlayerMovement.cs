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
    public float horizontal;
    public float vertical;

    Rigidbody rb; // referans tipi değişken
    public GameObject bulletPrefab;
    public void Start()
    {
        realSpeed = moveSpeed;
        rb = GetComponent<Rigidbody>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    void Update()
    {
        WalkAndRun();
        vertical = Input.GetAxis("Vertical");
        horizontal = Input.GetAxis("Horizontal");
        
        Vector3 direction = new Vector3(horizontal, 0, vertical);

        direction = transform.TransformDirection(direction);

        rb.MovePosition(transform.position +  direction * Time.deltaTime * realSpeed);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * 500);

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
        Camera.main.transform.rotation = Quaternion.Euler(rotX, rotY, 0);
        Camera.main.transform.position = transform.position;

        if(Input.GetMouseButtonDown(0))
        {
            GameObject bulletObject = Instantiate(bulletPrefab);
            bulletObject.transform.position = Camera.main.transform.position + Camera.main.transform.forward;
            bulletObject.transform.forward = Camera.main.transform.forward;
        }
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

    

}
