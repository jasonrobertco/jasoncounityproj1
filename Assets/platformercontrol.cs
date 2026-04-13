
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

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnMove(InputValue value)
    {
        Vector2 v = value.Get<Vector2>();
        Debug.Log(v);

        //changing velocity to want

        rb.linearVelocity = new Vector2(v.x * speed, rb.linearVelocity.y);
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
