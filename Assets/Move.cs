using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.SceneManagement;
using UnityEngine.Animations;
using System;

public class Move : MonoBehaviour
{
    private bool facingRight;
    public float playerSpeed;

    private Rigidbody2D rb;
    private Animator anim;
    
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        facingRight = true;
    }

    void Update()
    {
        playerSpeed = CrossPlatformInputManager.GetAxis("Horizontal");
        rb.velocity = new UnityEngine.Vector2(playerSpeed * 10, 0);
        Flip(playerSpeed);
        if (playerSpeed != 0)
        {
            anim.SetBool("isWalking", true);
        }
        if (playerSpeed == 0)
        {
            anim.SetBool("isWalking", false);
        }
    }

    private void Flip(float playerSpeed)
    {
        if (playerSpeed > 0 && !facingRight || playerSpeed < 0 && facingRight)
        {
            facingRight = !facingRight;
            UnityEngine.Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Door")
        {
            Console.WriteLine("Tag");
            SceneManager.LoadScene("Map");
        }
    }
}
