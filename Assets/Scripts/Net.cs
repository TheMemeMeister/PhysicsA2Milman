using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Net : MonoBehaviour
{
    public Rigidbody r_ball;
    public GameObject ballspawn;
    int lives = 3; //can use this later to implement a lives system and end screen
    

    void Start()
    {

        r_ball.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (lives == 0 )
        {
            //obs this is where I switch scenes to lose scene 
        }
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            //resets position of the ball when ball falls out of the play area 
            r_ball.velocity = Vector3.zero;
            r_ball.transform.position = ballspawn.transform.position;
            Debug.Log("Ball fell out of bounds");
            lives--; 

        }
    }
}
