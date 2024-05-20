using System.Runtime.InteropServices.WindowsRuntime;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 500f;

    public float floorTorqueStep = 400f;

    public float jumpTorqueStep = 50f;

    public bool isJumping;

    public float jumpStrength = 0f;
    public float maxJumpStrength = 500f;
    public float jumpStrengthStep = 1f;

    // private float Move;
    private Rigidbody2D rb;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        isJumping = false;
        jumpStrength = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        // Move = Input.GetAxis("Horizontal");
        
        rb.velocity = new Vector2(speed * Time.fixedDeltaTime, rb.velocity.y);

        if (Input.GetKey(KeyCode.UpArrow) && !isJumping) {
            jumpStrength += jumpStrengthStep * Time.fixedDeltaTime;
        }

        if (Input.GetKeyUp(KeyCode.UpArrow) && !isJumping) {
            float jump = Mathf.Min(jumpStrength, maxJumpStrength);
            rb.AddForce(new Vector2(rb.velocity.x, jump));
            jumpStrength = 0f;
        }

        // if (Input.GetButtonDown("Jump") && !isJumping) {
        //     animator.SetTrigger("jump");
            
        // }

        if (Input.GetKey(KeyCode.LeftArrow)) {
            if (isJumping) {
                rb.totalTorque += jumpTorqueStep * Time.deltaTime;
            } else {
                rb.totalTorque += floorTorqueStep * Time.deltaTime;

                // Debug.Log(Mathf.Abs(SignedAngle(transform.eulerAngles.z, 270f)));
                if (Mathf.Abs(SignedAngle(transform.eulerAngles.z, 270f)) < 10f) {
                    rb.totalTorque += 5 * jumpTorqueStep * Time.deltaTime;
                }
            }
        }
        if (Input.GetKey(KeyCode.RightArrow)) {
            if (isJumping) {
                rb.totalTorque -= jumpTorqueStep * Time.deltaTime;
            } else {
                rb.totalTorque -= floorTorqueStep * Time.deltaTime;

                // Debug.Log(Mathf.Abs(SignedAngle(transform.eulerAngles.z, 90f)));
                if (Mathf.Abs(SignedAngle(transform.eulerAngles.z, 90f)) < 10f) {
                    rb.totalTorque -= 5 * jumpTorqueStep * Time.deltaTime;
                }
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Platform")) {
            isJumping = false;
            rb.totalTorque = 0f;
            animator.SetBool("isAngry", true);
        }
    }

    private void OnCollisionExit2D(Collision2D other) {
        if (other.gameObject.CompareTag("Platform")) {
            isJumping = true;
            jumpStrength = 0f;
            animator.SetBool("isAngry", false);
        }
    }


    private float CustomMod(float a, int n) {
        return (a % n + n) % n;
    }
    private float SignedAngle(float angleA, float angleB) {
        float a = angleA - angleB;
        return CustomMod(a + 180, 360) - 180;
    }
}
