using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlungerBehaviour : MonoBehaviour
{
    [SerializeField, HideInInspector]
    public float PlungeForce;
    [SerializeField, Range(1, 1000), Tooltip("Maximum Force of Plunger")]
    public float PlungeMax = 100f;

    List<Rigidbody> Ballrb;
    public Slider PSlider;

    bool bFiring = false;
    // Start is called before the first frame update
    void Start()
    {
        PSlider.minValue = 0.0f;
        PSlider.maxValue = PlungeMax;
        Ballrb = new List<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(bFiring)
        {
            PSlider.gameObject.SetActive(true);
        }
        else
        {
            PSlider.gameObject.SetActive(false);
        }
        PSlider.value = PlungeForce;
        //ball is in trigger
        if (Ballrb.Count > 0)
        {
            //Punger Input is pressed
            bFiring = true;
            if (Input.GetKeyDown(KeyCode.Space)) //redo this with action mappings in project settings 
            {
                //while Plungeforce < Maxforce
                if (PlungeForce <= PlungeMax)
                {
                    PlungeForce += 50 * Time.deltaTime;
                }
            }
            if (Input.GetKeyUp(KeyCode.Space))
            {
                foreach(Rigidbody r in Ballrb)
                {
                    r.AddForce(PlungeForce * Vector3.forward);
                }
            }
        }
        else
        {
            bFiring = false;
            PlungeForce = 0;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            Ballrb.Add(other.gameObject.GetComponent<Rigidbody>());
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            Ballrb.Remove(other.gameObject.GetComponent<Rigidbody>());
            PlungeForce = 0f;
        }
    }
}
