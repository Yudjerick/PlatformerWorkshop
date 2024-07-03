using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdvancedPlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    bool canJump = true;
    int coins = 0;
    [SerializeField] float speed = 3f;
    [SerializeField] float jumpForce = 400f;
    [SerializeField] Transform start;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); 
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && canJump) 
        {
            rb.AddForce(Vector3.up * jumpForce);
        }
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, rb.velocity.y);
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        canJump = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Coin"))
        {
            coins++;
            print(coins);
            Destroy(other.gameObject);
        }
        if (other.CompareTag("Ground"))
        {
            canJump = true;
        }
        if (other.CompareTag("Danger"))
        {
            transform.position = start.position;
            canJump = true;
            rb.velocity = Vector2.zero;
        }
    }
}
