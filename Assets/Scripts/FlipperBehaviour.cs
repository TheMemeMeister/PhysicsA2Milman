using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlipperBehaviour : MonoBehaviour
{
    
    [SerializeField, Range(1, 100000), Tooltip("How many Newtons Flippers use to hit ball")]
    public float hitForce = 1000f;
    [SerializeField, Range(1, 1000), Tooltip("Friction on Flipper")]
    public float flipperFriction = 150;

    public float resetposition = 0f;
    public float pressedPosition = 45f; //Use gameobjects intead?

    public string inputType;
    HingeJoint Hj;
    // Start is called before the first frame update
    void Start()
    {
        Hj = GetComponent<HingeJoint>();
        Hj.useSpring = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     void FixedUpdate()
    {
        JointSpring spring = new JointSpring();
        spring.spring = hitForce;
        spring.damper = flipperFriction;
        if (Input.GetAxis(inputType) == 1)
        {
            spring.targetPosition = pressedPosition;
        }
        else
        {
            spring.targetPosition = resetposition;
        }
        Hj.spring = spring;
        Hj.useLimits = true;  //might want to clamp this instead
    }
}
