using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
 class Score : MonoBehaviour
{
    public Rigidbody r_ball;
    //public Rigidbody r_robo;
    public TextMeshProUGUI scoreText;
    public static int fScore;
 
    private void Start()
    {
        //scoreText = GetComponent<TextMeshProUGUI>();
        fScore = 0;
    }
    // Update is called once per frame
    void Update()
    {

        scoreText.text = "Score: " + fScore.ToString();
       
    }
    
}
