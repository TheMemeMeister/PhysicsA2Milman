using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
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
            Debug.Log("Lives: " + lives);

        }
    }
}
