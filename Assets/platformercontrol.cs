
using NUnit.Framework;
using UnityEngine;
using UnityEngine.InputSystem;


public class platformercontrol : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float speed;
    public float jumpForce;

    private Rigidbody2D rb;

    public int coinsCollected = 0;
    bool isGrounded = false;
    bool isFacingRight = true;
    private Animator playerAnim;
    private SpriteRenderer playerSpriteRenderer;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerAnim = GetComponent<Animator>();
        playerSpriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        playerAnim.SetBool("isRunning", rb.linearVelocity.x != 0);
        playerAnim.SetBool("isGrounded", isGrounded);
        //playerAnim.SetBool("JumpTrigger", ;
    }
    void OnMove(InputValue value)
    {
        Vector2 v = value.Get<Vector2>();
        Debug.Log(v);

        //changing velocity to want

        rb.linearVelocity = new Vector2(v.x * speed, rb.linearVelocity.y);
        playerAnim.SetBool("isRunning", rb.linearVelocity.x != 0);
        if((v.x < 0) && isFacingRight)
        {
            playerSpriteRenderer.flipX = true;
            isFacingRight = false;
        }
        if((v.x > 0) && !isFacingRight)
        {
            playerSpriteRenderer.flipX = false;
            isFacingRight = true;
        }
        //playerSpriteRenderer.flipX = ;
    }


    void OnJump()
    {
        if (isGrounded)
        {
           rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse); 
        }
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        isGrounded = true;
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        isGrounded = false;
    }
}
