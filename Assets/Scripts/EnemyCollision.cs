using UnityEngine;

public class EnemyCollision : MonoBehaviour
{

    private Rigidbody2D rb;
    private Collider2D col;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player")) {
            rb.AddForce(new Vector2(200, 400));
            GetComponent<AudioSource>().Play();
            other.gameObject.GetComponent<Animator>().SetTrigger("punch");
            other.gameObject.GetComponent<EndGame>().killCount++;
            col.enabled = false;
        }
    }
}
