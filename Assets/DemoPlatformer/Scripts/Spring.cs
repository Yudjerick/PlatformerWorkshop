using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spring : MonoBehaviour
{
    [SerializeField] private float launchSpeed;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            var otherRb = collision.GetComponent<Rigidbody2D>();
            otherRb.velocity = new Vector2(otherRb.velocity.x, launchSpeed);
        }
    }
}
