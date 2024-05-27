using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EndCinematic : MonoBehaviour
{

    public GameObject pot;
    public GameObject banana;
    public Transform finalBananaLocation;
    public Transform endLocation;

    public float walkingSpeed = 4f;

    private bool waitingForInput = false;

    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        // gameObject.GetComponent<PlayerMovement>().enabled = false;
        animator = gameObject.GetComponent<Animator>();
        waitingForInput = false;
    }

    void OnEnable() {
        Debug.Log("Starting cinematic n°2");
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2();
        gameObject.GetComponent<PlayerMovement>().enabled = false;
        gameObject.GetComponent<Animator>().SetBool("isWalking", true);
        gameObject.GetComponent<Animator>().SetFloat("walkingSpeed", 0.1f);
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
        if (transform.position.x < endLocation.position.x) {
            transform.position += new Vector3(walkingSpeed * Time.deltaTime, 0f);
        } else {
            if (!waitingForInput) {
                gameObject.GetComponent<Animator>().SetBool("isWalking", false);
                waitingForInput = true;
            }
        }
        if (waitingForInput && Input.GetKeyDown(KeyCode.Space)) {
            banana.transform.position = finalBananaLocation.position;
            banana.transform.rotation = finalBananaLocation.rotation;
            StartCoroutine(TriggerEnd());
        }
    }

    IEnumerator TriggerEnd() {
        yield return new WaitForSeconds(1.5f);
        gameObject.GetComponent<EndGame>().End(false);
    }
}