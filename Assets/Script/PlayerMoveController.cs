using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class PlayerMoveController : MonoBehaviour
{
    Animator anim;
    Rigidbody2D right;

    public int JumpPower;
    public int MoveSpeed;
    private bool IsJumping;


    // Start is called before the first frame update
    void Start()
    {
        right = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
       
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



        if (pos.x < 0f)
        {
            pos.x = 0f;
            anim.SetBool("isWalk", true);
        }
        else if (pos.x > 1f)
        {
            pos.x = 1f;
            anim.SetBool("isWalk", true);
        }
        else
        {
            anim.SetBool("isWalk", false);
        }

        if (pos.y < 0f)
        {
            pos.y = 0f;
            anim.SetBool("isWalk", true);
        }
        else if (pos.y > 1f)
        {
            pos.y = 1f;
            anim.SetBool("isWalk", true);
        }
        else
        {
            anim.SetBool("isWalk", false);
        }
        

        if (x < 0)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
            if (IsJumping == false) anim.SetBool("isWalk", true);
        }
        else if (x > 0)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
            if(IsJumping == false) anim.SetBool("isWalk", true);
        }
        else
        {
            if (IsJumping == false) anim.SetBool("isWalk", false);
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
                anim.SetBool("doJump", true);

            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            IsJumping = false;
            anim.SetBool("doJump", false);
        }
    }

}

