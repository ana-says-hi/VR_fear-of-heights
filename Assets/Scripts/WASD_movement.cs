using UnityEngine;

public class WASD_movement : MonoBehaviour
{
    public float moveSpeed = 10f;       // Speed of smooth movement
    //public float stepDistance = 1f;    // Distance the camera moves with each step
    Rigidbody rb;
    BoxCollider bc;

    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        bc = this.GetComponent<BoxCollider>();
    }

    void Update()
    {
        //bc.transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);
        HandleMovement();
    }

    void HandleMovement()
    {
        if (Input.GetKey(KeyCode.W)) rb.AddForce(transform.forward*moveSpeed);
        if (Input.GetKey(KeyCode.S)) rb.AddForce(transform.forward*moveSpeed*-1);
        if (Input.GetKey(KeyCode.A)) rb.AddForce(transform.right*moveSpeed*-1);
        if (Input.GetKey(KeyCode.D)) rb.AddForce(transform.right*moveSpeed);
    }
}
