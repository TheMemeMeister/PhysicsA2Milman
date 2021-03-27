using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Score : MonoBehaviour
{
    public Rigidbody r_ball;
    //public Rigidbody r_robo;
    public TextMeshProUGUI scoreText;
    public int fScore;
    private void Start()
    {
        //scoreText = GetComponent<TextMeshProUGUI>();
        fScore = 0;
    }
    // Update is called once per frame
    void Update()
    {
     
        scoreText.text = fScore.ToString();
    }
    private void OnCollisionEnter(Collision other)
    {

        if (other.gameObject.CompareTag("BashToy"))
        {
            //SoundManagerScript.PlaySound("GoalSound");
            r_ball = other.gameObject.GetComponent<Rigidbody>();

            fScore += 200;
        }
    }
}
