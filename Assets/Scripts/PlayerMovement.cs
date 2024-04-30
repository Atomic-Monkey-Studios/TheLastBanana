using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Build.Content;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float jump;

    public bool isJumping;

    private float Move;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        isJumping = false;
    }

    // Update is called once per frame
    void Update()
    {
        Move = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(speed * Time.fixedDeltaTime, rb.velocity.y);

        if (Input.GetButtonDown("Jump") && !isJumping) {
            rb.AddForce(new Vector2(rb.velocity.x, jump));
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Platform")) {
            isJumping = false;
        } else if (other.gameObject.CompareTag("Enemy")) {
            Debug.Log("OK");
            // int TransparentEntity = LayerMask.NameToLayer("TransparentEntity");
            // other.gameObject.layer = TransparentEntity;

            Rigidbody2D otherRb = other.gameObject.GetComponent<Rigidbody2D>();
            otherRb.AddForce(new Vector2(200, 400));

        }
    }

    private void OnCollisionExit2D(Collision2D other) {
        if (other.gameObject.CompareTag("Platform")) {
            isJumping = true;
        }
    }
}
