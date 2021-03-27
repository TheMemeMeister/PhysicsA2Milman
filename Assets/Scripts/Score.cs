using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Score : MonoBehaviour
{
    public Rigidbody r_ball;
    //public Rigidbody r_robo;
    public Text scoreText;
    public float fScore = 0;

    private void Start()
    {
        scoreText = FindObjectOfType<Text>();
    }
    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + fScore;
    }
    private void OnCollisionEnter(Collision other)
    {

        if (other.gameObject.CompareTag("BashToy"))
        {
            //SoundManagerScript.PlaySound("GoalSound");
            r_ball = other.gameObject.GetComponent<Rigidbody>();

            fScore+= 200;
        }
    }
}
