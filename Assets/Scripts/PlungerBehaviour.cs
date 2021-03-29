using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlungerBehaviour : MonoBehaviour
{
    [SerializeField, HideInInspector]
    public float PlungeForce;
    public float PlungeMax = 100f;

    List<Rigidbody> Ballrb;
    public Slider PSlider;

    [SerializeField]
    private float m_fSpringConstant;
    [SerializeField]
    private float m_fDampingConstant;
    [SerializeField]
    private Vector3 m_vRestPos;
    [SerializeField]
    private float m_fMass;
    [SerializeField]
    private Rigidbody m_attachedBody = null;
    [SerializeField]
    private bool m_bIsBungee = false;

    private Vector3 m_vForce;
    private Vector3 m_vPrevVel;

    bool bFiring;
    // Start is called before the first frame update
    void Start()
    {
        PSlider.minValue = 0.0f;
        PSlider.maxValue = PlungeMax;
        Ballrb = new List<Rigidbody>();
        m_fMass = m_attachedBody.mass;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        UpdateSpringForce();
        if (bFiring)
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
                Debug.Log("Space is pressed");
                //while Plungeforce < Maxforce
                if (PlungeForce <= PlungeMax)
                {
                    PlungeForce += 100 * Time.deltaTime;
                    m_attachedBody.MovePosition(new Vector3(0.0f, PlungeForce, 0.0f));
                }
            }
            if (Input.GetKeyUp(KeyCode.Space))
            {
                foreach(Rigidbody r in Ballrb)
                {
                    r.AddForce(PlungeForce * Vector3.forward);
                    //m_attachedBody.isKinematic = false;
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
    private float CalculateSpringConstant()
    {
        // k = F / dX
        // F = m * a
        // k = m * a / (xf - xi)

        float fDX = (m_vRestPos - m_attachedBody.transform.position).magnitude;

        if (fDX <= 0f)
        {
            return Mathf.Epsilon;
        }

        return (m_fMass * Physics.gravity.y) / (fDX);
    }
    private void UpdateSpringForce()
    {
        // F = -kx
        // F = -kx -bv

        if (m_bIsBungee)
        {
            float fLen = (m_vRestPos - m_attachedBody.transform.position).magnitude;

            if (fLen <= m_vRestPos.y)
            {
                return;
            }
        }

        m_vForce = -m_fSpringConstant * (m_vRestPos - m_attachedBody.transform.position) -
            m_fDampingConstant * (m_attachedBody.velocity - m_vPrevVel)* PlungeForce/100;

        m_attachedBody.AddForce(m_vForce, ForceMode.Acceleration);

        m_vPrevVel = m_attachedBody.velocity;
    }
}
