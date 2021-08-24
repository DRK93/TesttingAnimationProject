using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    private Animator m_Animator;
    private Rigidbody m_Rb;
    public float jumpForce = 500;
    public float groundDistance = 0.3f;
    public LayerMask whatIsGround;

    // Start is called before the first frame update
    void Start()
    {
        m_Animator = GetComponent<Animator>();
        m_Rb = GetComponent<Rigidbody>();
        //m_Animator.SetTrigger("Jump");
    }

    // Update is called once per frame
    void Update()
    {
        var v = Input.GetAxis("Vertical");
        var h = Input.GetAxis("Horizontal");
        m_Animator.SetFloat("Speed", v, 0.1f, Time.deltaTime);
        m_Animator.SetFloat("TurningSpeed", h, 0.1f, Time.deltaTime);

        if(Input.GetKeyDown(KeyCode.Space))
        {
            m_Rb.AddForce(Vector3.up * jumpForce);
            m_Animator.SetTrigger("Jump");
        }

        if (Physics.Raycast (transform.position + (Vector3.up *0.1f), Vector3.down, groundDistance, whatIsGround))
        {
            m_Animator.SetBool("Grounded", true);
            m_Animator.applyRootMotion = true;
        }
        else
        {
            m_Animator.SetBool("Grounded", false);
        }
    }
}
