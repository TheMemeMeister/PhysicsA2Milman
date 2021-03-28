using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class BumperBehaviour : MonoBehaviour
{
    private Rigidbody r_ball;
    Vector3 oldVel;


    void Start()
    {
      
        r_ball = GameObject.FindGameObjectWithTag("Ball").GetComponent<Rigidbody>();
        //scoreText = GetComponent<TextMeshProUGUI>();
    }

    void FixedUpdate()
    {
        oldVel = r_ball.velocity;
      
    }
   

    void OnCollisionEnter(Collision other)
    {
        Debug.Log("Collision");
        if (other.gameObject.CompareTag("Bumper"))
        {
            Debug.Log("Collision with active Bumper");
            ContactPoint cp = other.contacts[0];
            // calculate with addition of normal vector
            // myRigidbody.velocity = oldVel + cp.normal*2.0f*oldVel.magnitude;

            // calculate with Vector3.Reflect
            r_ball.velocity = Vector3.Reflect(oldVel, cp.normal);

            // bumper effect to speed up ball
            r_ball.velocity += cp.normal * 2.0f;

         
        }
        if (other.gameObject.CompareTag("Passsive Bumper"))
        {
            Debug.Log("Collision with passive Bumper");
            ContactPoint cp = other.contacts[0];
            // calculate with addition of normal vector
            // myRigidbody.velocity = oldVel + cp.normal*2.0f*oldVel.magnitude;

            // calculate with Vector3.Reflect
            r_ball.velocity = Vector3.Reflect(oldVel, cp.normal);
            //not adding the extra boost for the passive bumpers. 
            r_ball.velocity = cp.normal;
         
        }

        if (other.gameObject.CompareTag("BashToy"))
        {
            //SoundManagerScript.PlaySound("GoalSound");
            r_ball = other.gameObject.GetComponent<Rigidbody>();

        
        }
    }

}