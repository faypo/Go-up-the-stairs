using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerController : MonoBehaviour
{
    Rigidbody2D rigid2D;
    Animator anima;

    public float jumpForce;
    public float walkSpeed;
    public float maxSpeed;

    public string scence;

    private void Start()
    {
        this.rigid2D = GetComponent<Rigidbody2D>();
        this.anima = GetComponent<Animator>();
    }

    private void Update()
    {

        jump();
        walk();
        flip();

        float speedx = Mathf.Abs(this.rigid2D.velocity.x);
        this.anima.speed = speedx / 2.0f;

        
    }

    

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("終點");
        SceneManager.LoadScene(scence);
    }

    private void walk()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rigid2D.velocity = new Vector2(-walkSpeed, rigid2D.velocity.y);
        } 
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rigid2D.velocity = new Vector2(walkSpeed, rigid2D.velocity.y);
        }
        else
        {
            rigid2D.velocity = new Vector2(0, rigid2D.velocity.y);
        }
    }

    private void flip()
    {
        bool playerHasXAxisSpeed = Mathf.Abs(rigid2D.velocity.x) > Mathf.Epsilon;
        if (playerHasXAxisSpeed)
        {
            if (rigid2D.velocity.x > 0.1f)
            {
                transform.localRotation = Quaternion.Euler(0, 0, 0);
            }

            if (rigid2D.velocity.x < -0.1f)
            {
                transform.localRotation = Quaternion.Euler(0, 180, 0);
            }
        }
    }

    private void jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && this.rigid2D.velocity.y == 0)
        {
            Vector2 jumpVec = new Vector2(0.0f, jumpForce);
            rigid2D.velocity = Vector2.up * jumpVec;
        }
    }
}