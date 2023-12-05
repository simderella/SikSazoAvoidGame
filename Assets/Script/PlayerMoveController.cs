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
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        


        if (pos.x < 0f) pos.x = 0f;
        else if (pos.x > 1f) pos.x = 1f;
        if (pos.y < 0f) pos.y = 0f;
        else if (pos.y > 1f) pos.y = 1f;

        if (x < 0)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        else if (x > 0)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }

        transform.position = Camera.main.ViewportToWorldPoint(pos);

        transform.Translate((new Vector2(x, 0) * MoveSpeed) * Time.deltaTime);
        //¿Ãµø
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

