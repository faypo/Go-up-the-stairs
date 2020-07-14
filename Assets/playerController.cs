using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    Rigidbody2D rigid2D;
    Animator anima;

    public float jumpForce;
    public float walkForce;
    public float maxSpeed;

    private void Start()
    {
        this.rigid2D = GetComponent<Rigidbody2D>();
        this.anima = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            this.rigid2D.AddForce(transform.up * this.jumpForce);
        }

        int key = 0;

        if (Input.GetKey(KeyCode.LeftArrow)) key = -1;
        if (Input.GetKey(KeyCode.RightArrow)) key = 1;

        float speedx = Mathf.Abs(this.rigid2D.velocity.x);

        if(speedx < this.maxSpeed)
        {
            this.rigid2D.AddForce(transform.right * key * this.walkForce);
        }

        if(key != 0)
        {
            transform.localScale = new Vector3(key, 1, 1);
        }

        this.anima.speed = speedx / 2.0f;
    }
}
