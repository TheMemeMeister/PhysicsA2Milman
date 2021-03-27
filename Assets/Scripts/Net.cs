using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Net : MonoBehaviour
{
    public Rigidbody r_ball;
    
    public GameObject ballspawn;
    // Start is called before the first frame update
    void Start()
    {

        r_ball.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            r_ball.velocity = Vector3.zero;
            r_ball.transform.position = ballspawn.transform.position;
            Debug.Log("Ball fell out of bounds");


        }
    }
}
