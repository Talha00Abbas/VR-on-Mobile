using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 25f;
    public float rotateSpeed = 25f;
    public bool turnRight = false;
    public bool turnLeft = false;
    public Rigidbody rb;
    public bool isGrounded = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        GroundCheck();
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        if (turnRight == true)
        {
            turnLeft = false;
            transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime);

        }

        if (turnLeft == true)
        {
            turnRight = false;
            transform.Rotate(Vector3.up * -(rotateSpeed) * Time.deltaTime);

        }

        if (Input.GetKey(KeyCode.Space) && isGrounded == true)
        {
            turnLeft = false;
            turnRight = false;
            rb.AddForce(Vector3.up * jumpForce);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            transform.Rotate(Vector3.up * 180);
        }
    }

    void GroundCheck()
    {
        RaycastHit hit;
        float distance = 1.5f;
        Vector3 dir = new Vector3(0, -0.75f);

        if (Physics.Raycast(transform.position, dir, out hit, distance))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }
}
