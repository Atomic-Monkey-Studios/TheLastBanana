using System.Runtime.InteropServices.WindowsRuntime;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 8.3333f;

    public float floorTorqueStep = 500f;

    public float jumpTorqueStep = 50f;

    public bool isJumping;

    public float jumpStrength = 0f;
    public float maxJumpStrength = 500f;
    public float jumpStrengthStep = 250f;

    public AudioSource audioSource;

    // private float Move;
    private Rigidbody2D rb;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
    }

    void OnEnable() {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        isJumping = false;
        jumpStrength = 0f;

        animator.SetBool("isWalking", true);
        animator.SetFloat("walkingSpeed", 0.25f);
    }

    // Update is called once per frame
    void Update()
    {
        // Move = Input.GetAxis("Horizontal");
        
        rb.velocity = new Vector2(speed, rb.velocity.y);

        // if (Input.GetKey(KeyCode.UpArrow) && !isJumping) {
        //     jumpStrength += jumpStrengthStep * Time.deltaTime;
        // }

        if (Input.GetKeyUp(KeyCode.UpArrow) && !isJumping) {
            float jump = Mathf.Min(jumpStrength, maxJumpStrength);
            audioSource.Play();
            rb.AddForce(new Vector2(rb.velocity.x, maxJumpStrength));
            jumpStrength = 0f;
        }
        
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
        if (!enabled) return; 
        if (other.gameObject.CompareTag("Platform")) {
            isJumping = false;
            rb.totalTorque = 0f;
            // animator.SetBool("isAngry", true);
        }
    }

    private void OnCollisionExit2D(Collision2D other) {
        if (!enabled) return; 
        if (other.gameObject.CompareTag("Platform")) {
            isJumping = true;
            jumpStrength = 0f;
            // animator.SetBool("isAngry", false);
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
