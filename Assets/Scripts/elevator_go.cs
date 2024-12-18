using System.Collections;
using System.Collections.Generic;
using UnityEngine;
                
public class elevator_go : MonoBehaviour
{   
    //https://youtu.be/JOiEz9fnc5Y?si=-hxth2NziHZHlq3X
    //video about movement

    public Rigidbody rb;
    public float forceStrength = 20;
    
    float forceControl;
    Vector3[] locations;

    private Vector3 targetPosition; // Current target position
    public float moveSpeed = 5f; // Movement speed

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Vector3 startPos=rb.position;

        //etaje la care se opreste
        int count = 10;
        locations = new Vector3[count];

        for (int i = 0; i < count; i++)
        {
            float yValue = 0.5f + (i * 5f);
            locations[i] = startPos + new Vector3(0, yValue, 0);
        }

        ChooseRandomTarget();
    }

    //de mai putine ori decat Update
    private void FixedUpdate()
    {
        //rb.AddForce(Vector3.up * forceControl * forceStrength);

        Vector3 direction = (targetPosition - rb.position).normalized;
        rb.AddForce(direction * forceStrength);

        if (Vector3.Distance(rb.position, targetPosition) < 0.1f)
        {
            rb.velocity = Vector3.zero;
            ChooseRandomTarget();
        }
    }

    // Update is called once per frame
    void Update()
    {
       forceControl =Input.GetAxis("Vertical");
    }


    void ChooseRandomTarget()
    {
        int randomIndex = Random.Range(0, locations.Length);
        targetPosition = locations[randomIndex];
    }
}