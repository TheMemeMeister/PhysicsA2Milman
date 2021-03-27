using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumperBehaviour : MonoBehaviour
{
    public Rigidbody r_ball;
    Vector3 oldVel;

    void Start()
    {
        r_ball = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        oldVel = r_ball.velocity;
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Bumper"))
        {
            Debug.Log("Collision with Bumper");
            ContactPoint cp = other.contacts[0];
            // calculate with addition of normal vector
            // myRigidbody.velocity = oldVel + cp.normal*2.0f*oldVel.magnitude;

            // calculate with Vector3.Reflect
            r_ball.velocity = Vector3.Reflect(oldVel, cp.normal);

            // bumper effect to speed up ball
            r_ball.velocity += cp.normal * 2.0f;
        }
    }
}
