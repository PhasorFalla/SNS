using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Grapple grapple;
    Rigidbody2D rb;
    float rotateSpeed;
    public float Bounce = 4;
    public float JumpVelocity = 400f;
    public float MoveSpeed = 5f;
    public bool IsGrounded = false;
    public float rotationMultiplyer = 1;
    private Transform myTransform;
    public int timesJumped;
    [HideInInspector]
    public GameObject DeathVFX;

    private NinjaStraps straps;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        grapple = GetComponent<Grapple>();
        straps = grapple.straps.GetComponent<NinjaStraps>();
    }


    void Update()
    {
        if(FanReset.deathzone.dead == true)
        {

            if(Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.A) || Input.GetMouseButtonDown(1))
            {
                FanReset.deathzone.dead = false;
            }
            else
            {
                return;

            }
        }

        if(Input.GetKey(KeyCode.D))
        {
            var xy = new Vector2(MoveSpeed, rb.velocity.y);
            rb.velocity = xy;
        }
        if (Input.GetKey(KeyCode.A))
        {
            var xy = new Vector2(MoveSpeed * -1, rb.velocity.y);
            rb.velocity = xy;
        }

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            straps.moving = true;
        }
        else
        {
            straps.moving = false;
        }

        if (Input.GetMouseButtonDown(1) || Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
        
        if (!IsGrounded)
        {
            rotateSpeed = (rb.velocity.x );
            rb.angularVelocity = rotateSpeed * Time.deltaTime * rotationMultiplyer;
        }

        if(rb.velocity.y < 0)
        {
            gameObject.layer = LayerMask.NameToLayer("PlayerGhost");
        }
        else
        {
            gameObject.layer = LayerMask.NameToLayer("Player");
        }


    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Floor"))
        {
            IsGrounded = true;
        }
        else if (collision.gameObject.CompareTag("Enemies"))
        {
            rb.velocity = new Vector2(0, 0);
            rb.AddForce(new Vector2(0, Bounce), ForceMode2D.Impulse);
        }


        if (collision.gameObject.tag == "Bomb")
        {
            grapple.Detatch();
            FanReset.deathzone.ResetEntity(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            IsGrounded = false;
        }
    }

    void Jump()
    {
        if(IsGrounded)
        {
            timesJumped = 1;
        }

        if(timesJumped < 2)
        {
            rb.AddForce(new Vector2(rb.velocity.x, JumpVelocity));
            IsGrounded = false;
        }

        timesJumped++;
    }
}