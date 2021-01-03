using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovemnt : MonoBehaviour
{
    public float speed;
    public float rotationSpeed;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        float mouseX = Input.GetAxis("Mouse X");

        rb.AddRelativeTorque(0, mouseX * rotationSpeed * Time.deltaTime, 0);

        if (Input.GetKey(KeyCode.W))
        {
            rb.AddRelativeForce(0, 0, speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.S))
        {
            rb.AddRelativeForce(0, 0, -speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.A))
        {
            rb.AddRelativeForce(-speed * Time.deltaTime, 0, 0);
        }

        if (Input.GetKey(KeyCode.D))
        {
            rb.AddRelativeForce(speed * Time.deltaTime, 0, 0);
        }

    }
}
