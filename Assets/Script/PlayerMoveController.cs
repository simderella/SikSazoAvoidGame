using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class NewBehaviourScript : MonoBehaviour
{
    private Rigidbody2D right;

    public int JumpPower;
    public int MoveSpeed;
    private bool IsJumping;

    // Start is called before the first frame update
    void Start()
    {
        right = GetComponent<Rigidbody2D>(); 
       
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
        
    }

    void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        if (transform.position.x > 3.0f)
        {
            transform.Translate((new Vector2(3, 0) * MoveSpeed) * Time.deltaTime);
        }
        else if(transform.position.x < -3.0f)
        {
            transform.Translate((new Vector2(-3, 0) * MoveSpeed) * Time.deltaTime);
        }
        else
        {
            transform.Translate((new Vector2(x, 0) * MoveSpeed) * Time.deltaTime);
        }
        

    }

    void Jump()
    {
        if (!IsJumping)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                IsJumping = true;
                right.AddForce(Vector2.up * JumpPower, ForceMode2D.Impulse);
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            IsJumping = false;
        }
    }

}

