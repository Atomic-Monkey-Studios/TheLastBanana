using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StartCinematic : MonoBehaviour
{

    public Transform displayPanelLocation;

    public float walkingSpeed = 1;


    private CinematicPhase phase = CinematicPhase.Start;

    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        // gameObject.GetComponent<PlayerMovement>().enabled = false;
        animator = gameObject.GetComponent<Animator>();
    }

    void OnEnable() {
        Debug.Log("Starting cinematic n°1");
        gameObject.GetComponent<PlayerMovement>().enabled = false;
        gameObject.GetComponent<Animator>().SetFloat("walkingSpeed", 0.1f);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < displayPanelLocation.position.x) {
            transform.position += new Vector3(walkingSpeed * Time.deltaTime, 0f);
        } else {
            if (phase == CinematicPhase.Start) {
                phase = CinematicPhase.Watching;
                animator.SetBool("isWalking", false);
                animator.SetBool("isAngry", true);

                StartCoroutine(wait());
            }
        }
    }

    IEnumerator wait() {
        yield return new WaitForSeconds(2);
        Debug.Log("on repart");

        gameObject.GetComponent<PlayerMovement>().enabled = true;
        gameObject.GetComponent<StartCinematic>().enabled = false;
    }

}



enum CinematicPhase {
    Start,
    Watching,
    Running,
}