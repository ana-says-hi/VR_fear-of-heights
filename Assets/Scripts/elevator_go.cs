using System.Collections;
using System.Collections.Generic;
using UnityEngine;
                
public class elevator_go : MonoBehaviour
{   
    //https://youtu.be/JOiEz9fnc5Y?si=-hxth2NziHZHlq3X
    //video about movement

    public Rigidbody rb;
    public float forceStrength = 20;
    
    //float forceControl;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    //de mai putine ori decat Update
    private void FixedUpdate()
    {
        //rb.AddForce(Vector3.up * forceControl * forceStrength);
        rb.AddForce(Vector3.up * forceStrength);
    }

    // Update is called once per frame
    void Update()
    {
        //forceControl =Input.GetAxis("Vertical");
    }
}
