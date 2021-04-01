using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CollisionManager : MonoBehaviour
{
    private Rigidbody r_ball;
    Vector3 oldVel;
    Score myscore;
    [SerializeField]
    AudioClip CollisionSound;
    [SerializeField]
    AudioClip RobotSound;
    void Start()
    {
        Score.fScore = 0;
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

            // adding transform to bumper to simulate hit effect
            other.transform.localScale = new Vector3(1.1f, 1.1f, 1.1f);

            AudioSource.PlayClipAtPoint(CollisionSound, other.transform.position);
            StartCoroutine(BumperDelay(other));
            


            //other.gameObject.getcomponent<Material>();
            //Setting the transform back 
            //gameObject.transform.localScale -= new Vector3(0.1f, 0.1f, 0);
            Score.fScore += 250;
            Debug.Log("Score is " + Score.fScore);

        }
        if (other.gameObject.CompareTag("Passsive Bumper"))
        {
            Debug.Log("Collision with passive Bumper");
            ContactPoint cp = other.contacts[0];
            // calculate with addition of normal vector
            // myRigidbody.velocity = oldVel + cp.normal*2.0f*oldVel.magnitude;
            AudioSource.PlayClipAtPoint(CollisionSound, other.transform.position);
            // calculate with Vector3.Reflect
            r_ball.velocity = Vector3.Reflect(oldVel, cp.normal);
            //Slowing down the ball on passive bumpers
            r_ball.velocity = cp.normal * 0.75f;
            Score.fScore += 100;
            Debug.Log("Score is " + Score.fScore);
            //SoundManager.PlaySound(SoundManager.Sound.RobotSound);
        }

        if (other.gameObject.CompareTag("BashToy"))
        {
            AudioSource.PlayClipAtPoint(RobotSound, other.transform.position);
            Score.fScore += 500;
            Debug.Log("Score is " + Score.fScore);

        }
    }
    IEnumerator BumperDelay(Collision other)
    {

        yield return new WaitForSeconds(0.1f);
        other.transform.localScale = new Vector3(0.9f, 0.9f, 0.9f);
        //other.gameObject.GetComponent<Light>().color = new Vector4(0.0f, 0.0f, 1.0f, 1.0f);
        Debug.Log("coroutine called");
    }
}
