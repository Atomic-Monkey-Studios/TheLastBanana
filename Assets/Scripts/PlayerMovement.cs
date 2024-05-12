using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float jump;

    public bool isJumping;

    private float customTorque = 0f;

    // private float Move;
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
        // Move = Input.GetAxis("Horizontal");
        
        rb.velocity = new Vector2(speed * Time.fixedDeltaTime, rb.velocity.y);
        if (Input.GetButtonDown("Jump") && !isJumping) {
            Debug.Log(Mathf.Abs(transform.eulerAngles.z));
            // rb.AddForce(new Vector2(rb.velocity.x, jump));
            if (Mathf.Abs(transform.eulerAngles.z) < 0.5) rb.AddForce(new Vector2(rb.velocity.x, jump));
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow)) {
            if (isJumping) {
                customTorque += 5f;
            } else {
                customTorque += 20f;
            }
            
            rb.AddTorque(customTorque);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow)) {
            if (isJumping) {
                customTorque -= 5f;
            } else {
                customTorque -= 20f;
            }
            rb.AddTorque(customTorque);
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Platform")) {
            isJumping = false;
            customTorque = 0f;
        }
    }

    private void OnCollisionExit2D(Collision2D other) {
        if (other.gameObject.CompareTag("Platform")) {
            isJumping = true;
            customTorque = 0f;
            rb.totalTorque = 0f;
        }
    }
}
