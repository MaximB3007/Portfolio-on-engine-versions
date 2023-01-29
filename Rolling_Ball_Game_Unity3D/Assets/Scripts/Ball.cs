using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour
{
    public int force;
    public int jumpForce;

    private Animator anim;
    private Rigidbody rb;
    private bool j;
    public float JumpDelay;
    public Button jump;
    private float t;

    private float velocity1 = 0;
    private float velocity2 = 0;
    //private float velocity3 = 0;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();      
        j = false;
        t = JumpDelay;
    }

    void Update()
    {
        anim.SetFloat("Velocity", rb.velocity.magnitude);
        anim.SetFloat("VerticalVelocity", rb.velocity.y);

        if (j)
        {
            t -= Time.deltaTime;
            if (t <= 0)
            {              
                t = JumpDelay;
                JumpUp();
            }
        }
    }

    private void FixedUpdate()
    {
        //velocity3 = velocity2;
        velocity2 = velocity1;
        velocity1 = GetComponent<Rigidbody>().velocity.y;
        
        if (velocity1 >= 0 & velocity2 < -0.1f)
        {
            anim.SetTrigger("Drop");
        }
    }

    public void Right()
    {
        Vector3 direction = new Vector3(1, 0, 0);
        GetComponent<Rigidbody>().velocity = direction * force;       
    }

    public void Left()
    {
        Vector3 direction = new Vector3(-1, 0, 0);
        GetComponent<Rigidbody>().velocity = direction * force;
    }

    public void Stop()
    {
        Vector3 direction = new Vector3(0, 0, 0);
        GetComponent<Rigidbody>().velocity = direction;
    }

    public void JumpUp()
    {
        if (j == false)
        { 
            jump.interactable = false;
            j = !j;
            anim.SetTrigger("Jump");
        }
        else
        {
            Vector3 direction = new Vector3(0, 1, 0);
            GetComponent<Rigidbody>().AddForce(direction * jumpForce, ForceMode.VelocityChange);
            j = !j;
            jump.interactable = true;
        }       
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("DeathTrigger"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        if (other.CompareTag("Finish"))
        {
            if (SceneManager.GetActiveScene().buildIndex == 5)
            {
                SceneManager.LoadScene(0);
            }
            else
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
    }
}
