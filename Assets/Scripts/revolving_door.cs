using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class revolving_door : MonoBehaviour
{
    private HingeJoint hingeJoint;
    public float pushForce = -50f;
    public bool isOpening = false;

    private void Start()
    {
        hingeJoint = GetComponent<HingeJoint>();
        JointMotor motor = hingeJoint.motor;
        motor.force = 100f;
        motor.targetVelocity = 0f;  // Initially no rotation
        hingeJoint.motor = motor;
        hingeJoint.useMotor = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("MainCamera"))
        {
            StartRotation(collision.relativeVelocity);
        }
    }

    private void StartRotation(Vector3 collisionForce)
    {
        JointMotor motor = hingeJoint.motor;
        motor.targetVelocity = pushForce;  // Rotate in the push direction
        hingeJoint.motor = motor;
        hingeJoint.useMotor = true;

        Invoke("StopDoor", 2f);  // Stop rotation after 2 seconds
    }

    private void StopDoor()
    {
        JointMotor motor = hingeJoint.motor;
        motor.targetVelocity = 0f;
        hingeJoint.motor = motor;
    }
}
